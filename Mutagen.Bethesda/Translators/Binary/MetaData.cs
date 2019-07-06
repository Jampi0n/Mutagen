﻿using Mutagen.Bethesda.Binary;
using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.Text;

namespace Mutagen.Bethesda.Binary
{
    public interface IRecordConstants
    {
        sbyte HeaderLength { get; }
        sbyte LengthLength { get; }
        sbyte LengthAfterLength { get; }
    }

    public class RecordConstants : IRecordConstants
    {
        public sbyte HeaderLength { get; set; }
        public sbyte LengthLength { get; set; }
        public sbyte LengthAfterLength { get; set; }
    }

    public class MetaDataConstants
    {
        public GameMode GameMode { get; private set; }
        public sbyte ModHeaderLength { get; private set; }
        public sbyte ModHeaderFluffLength { get; private set; }

        public IRecordConstants GroupConstants { get; private set; }
        public IRecordConstants MajorConstants { get; private set; }
        public IRecordConstants SubConstants { get; private set; }

        public static readonly MetaDataConstants Oblivion = new MetaDataConstants()
        {
            GameMode = GameMode.Oblivion,
            ModHeaderLength = 20,
            ModHeaderFluffLength = 12,
            GroupConstants = new RecordConstants()
            {
                HeaderLength = 20,
                LengthLength = 4,
                LengthAfterLength = 12,
            },
            MajorConstants = new RecordConstants()
            {
                HeaderLength = 20,
                LengthLength = 4,
                LengthAfterLength = 12,
            },
            SubConstants = new RecordConstants()
            {
                HeaderLength = 6,
                LengthLength = 2,
                LengthAfterLength = 0,
            }
        };

        public static readonly MetaDataConstants Skyrim = new MetaDataConstants()
        {
            GameMode = GameMode.Skyrim,
            ModHeaderLength = 24,
            ModHeaderFluffLength = 16,
            GroupConstants = new RecordConstants()
            {
                HeaderLength = 24,
                LengthLength = 4,
                LengthAfterLength = 16,
            },
            MajorConstants = new RecordConstants()
            {
                HeaderLength = 24,
                LengthLength = 4,
                LengthAfterLength = 16,
            },
            SubConstants = new RecordConstants()
            {
                HeaderLength = 4,
                LengthLength = 2,
                LengthAfterLength = 0,
            }
        };

        public ModHeaderMeta Header(ReadOnlySpan<byte> span) => new ModHeaderMeta(this, span);
        public ModHeaderMeta GetHeader(IMutagenReadStream stream) => new ModHeaderMeta(this, stream.GetSpan(this.ModHeaderLength));
        public ModHeaderMeta ReadHeader(IMutagenReadStream stream) => new ModHeaderMeta(this, stream.ReadSpan(this.ModHeaderLength));
        public GroupRecordMeta Group(ReadOnlySpan<byte> span) => new GroupRecordMeta(this, span);
        public GroupRecordMeta GetGroup(IMutagenReadStream stream) => new GroupRecordMeta(this, stream.GetSpan(this.GroupConstants.HeaderLength));
        public GroupRecordMeta ReadGroup(IMutagenReadStream stream) => new GroupRecordMeta(this, stream.ReadSpan(this.GroupConstants.HeaderLength));
        public MajorRecordMeta MajorRecord(ReadOnlySpan<byte> span) => new MajorRecordMeta(this, span);
        public MajorRecordMeta GetMajorRecord(IMutagenReadStream stream) => new MajorRecordMeta(this, stream.GetSpan(this.MajorConstants.HeaderLength));
        public MajorRecordMeta ReadMajorRecord(IMutagenReadStream stream) => new MajorRecordMeta(this, stream.ReadSpan(this.MajorConstants.HeaderLength));
        public SubRecordMeta SubRecord(ReadOnlySpan<byte> span) => new SubRecordMeta(this, span);
        public SubRecordMeta GetSubRecord(IMutagenReadStream stream) => new SubRecordMeta(this, stream.GetSpan(this.SubConstants.HeaderLength));
        public SubRecordMeta ReadSubRecord(IMutagenReadStream stream) => new SubRecordMeta(this, stream.ReadSpan(this.SubConstants.HeaderLength));

        public static MetaDataConstants Get(GameMode mode)
        {
            switch (mode)
            {
                case GameMode.Oblivion:
                    return Oblivion;
                case GameMode.Skyrim:
                    return Skyrim;
                default:
                    throw new NotImplementedException();
            }
        }

        public static implicit operator MetaDataConstants(GameMode mode)
        {
            return Get(mode);
        }
    }

    public ref struct ModHeaderMeta
    {
        private MetaDataConstants meta;
        public ReadOnlySpan<byte> Span { get; }

        public ModHeaderMeta(MetaDataConstants meta, ReadOnlySpan<byte> span)
        {
            this.meta = meta;
            this.Span = span.Slice(0, meta.ModHeaderLength);
        }

        public GameMode GameMode => meta.GameMode;
        public bool HasContent => this.Span.Length >= this.HeaderLength;
        public sbyte HeaderLength => meta.ModHeaderLength;
        public RecordType RecordType => new RecordType(BinaryPrimitives.ReadInt32LittleEndian(this.Span.Slice(0, 4)));
        public uint RecordLength => BinaryPrimitives.ReadUInt32LittleEndian(this.Span.Slice(4, 4));
        public long TotalLength => this.HeaderLength + this.RecordLength;
    }

    public ref struct GroupRecordMeta
    {
        private MetaDataConstants meta;
        public ReadOnlySpan<byte> Span { get; }

        public GroupRecordMeta(MetaDataConstants meta, ReadOnlySpan<byte> span)
        {
            this.meta = meta;
            this.Span = span.Slice(0, meta.GroupConstants.HeaderLength);
        }

        public GameMode GameMode => meta.GameMode;
        public sbyte HeaderLength => meta.GroupConstants.HeaderLength;
        public RecordType RecordType => new RecordType(BinaryPrimitives.ReadInt32LittleEndian(this.Span.Slice(0, 4)));
        public uint RecordLength => BinaryPrimitives.ReadUInt32LittleEndian(this.Span.Slice(4, 4));
        public ReadOnlySpan<byte> ContainedRecordTypeSpan => this.Span.Slice(8, 4);
        public RecordType ContainedRecordType => new RecordType(BinaryPrimitives.ReadInt32LittleEndian(this.ContainedRecordTypeSpan));
        public int GroupType => BinaryPrimitives.ReadInt32LittleEndian(this.Span.Slice(12, 4));
        public ReadOnlySpan<byte> LastModifiedSpan => this.Span.Slice(16, 4);
        public long TotalLength => this.RecordLength;
        public bool IsGroup => this.RecordType == Constants.GRUP;
        public uint ContentLength => checked((uint)(this.TotalLength - this.HeaderLength));
    }

    public ref struct MajorRecordMeta
    {
        private MetaDataConstants meta;
        public ReadOnlySpan<byte> Span { get; }

        public MajorRecordMeta(MetaDataConstants meta, ReadOnlySpan<byte> span)
        {
            this.meta = meta;
            this.Span = span.Slice(0, meta.MajorConstants.HeaderLength);
        }

        public GameMode GameMode => meta.GameMode;
        public sbyte HeaderLength => meta.MajorConstants.HeaderLength;
        public RecordType RecordType => new RecordType(BinaryPrimitives.ReadInt32LittleEndian(this.Span.Slice(0, 4)));
        public uint RecordLength => BinaryPrimitives.ReadUInt32LittleEndian(this.Span.Slice(4, 4));
        public int MajorRecordFlags => BinaryPrimitives.ReadInt32LittleEndian(this.Span.Slice(8, 4));
        public FormID FormID => FormID.Factory(BinaryPrimitives.ReadUInt32LittleEndian(this.Span.Slice(12, 4)));
        public long TotalLength => this.HeaderLength + this.RecordLength;
    }

    public ref struct SubRecordMeta
    {
        private MetaDataConstants meta;
        public ReadOnlySpan<byte> Span { get; }

        public SubRecordMeta(MetaDataConstants meta, ReadOnlySpan<byte> span)
        {
            this.meta = meta;
            this.Span = span.Slice(0, meta.SubConstants.HeaderLength);
        }

        public GameMode GameMode => meta.GameMode;
        public sbyte HeaderLength => meta.SubConstants.HeaderLength;
        public RecordType RecordType => new RecordType(BinaryPrimitives.ReadInt32LittleEndian(this.Span.Slice(0, 4)));
        public ushort RecordLength => BinaryPrimitives.ReadUInt16LittleEndian(this.Span.Slice(4, 2));
        public long TotalLength => this.HeaderLength + this.RecordLength;
    }
}
