﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mutagen.Binary
{
    public class HeaderTranslation
    {
        public static bool TryParse(
            BinaryReader reader,
            RecordType expectedHeader,
            out int contentLength,
            int lengthLength)
        {
            var header = reader.ReadChars(Constants.HEADER_LENGTH);
            if (!expectedHeader.Equals(header))
            {
                contentLength = 0;
                reader.BaseStream.Position -= Constants.HEADER_LENGTH;
                return false;
            }
            switch (lengthLength)
            {
                case 1:
                    contentLength = reader.ReadByte();
                    break;
                case 2:
                    contentLength = reader.ReadInt16();
                    break;
                case 4:
                    contentLength = reader.ReadInt32();
                    break;
                default:
                    throw new NotImplementedException();
            }
            return true;
        }

        public static int Parse(
            BinaryReader reader,
            RecordType expectedHeader,
            int lengthLength)
        {
            if (!TryParse(
                reader,
                expectedHeader,
                out var contentLength,
                lengthLength))
            {
                throw new ArgumentException($"Expected header was not read in: {expectedHeader}");
            }
            return contentLength;
        }

        public static long ParseRecord(
            BinaryReader reader,
            RecordType expectedHeader)
        {
            if (!TryParse(
                reader,
                expectedHeader,
                out var contentLength,
                Constants.RECORD_LENGTHLENGTH))
            {
                throw new ArgumentException($"Expected header was not read in: {expectedHeader}");
            }
            return reader.BaseStream.Position + contentLength + Constants.RECORD_HEADER_SKIP;
        }

        public static long ParseSubrecord(
            BinaryReader reader,
            RecordType expectedHeader)
        {
            if (!TryParse(
                reader,
                expectedHeader,
                out var contentLength,
                Constants.SUBRECORD_LENGTHLENGTH))
            {
                throw new ArgumentException($"Expected header was not read in: {expectedHeader}");
            }
            return reader.BaseStream.Position + contentLength;
        }

        public static bool TryParseSubRecordType(
            BinaryReader reader,
            RecordType expectedHeader)
        {
            if (TryParse(
                reader,
                expectedHeader,
                out var contentLength,
                Constants.SUBRECORD_LENGTHLENGTH))
            {
                return true;
            }
            return false;
        }

        public static long GetSubrecord(
            BinaryReader reader,
            RecordType expectedHeader)
        {
            var ret = ParseSubrecord(
                reader,
                expectedHeader);
            reader.BaseStream.Position -= Constants.SUBRECORD_LENGTH;
            return ret;
        }

        public static RecordType ReadNextRecordType(
            BinaryReader reader,
            int lengthLength,
            out int contentLength)
        {
            var header = reader.ReadChars(Constants.HEADER_LENGTH);
            switch (lengthLength)
            {
                case 1:
                    contentLength = reader.ReadByte();
                    break;
                case 2:
                    contentLength = reader.ReadUInt16();
                    break;
                case 4:
                    contentLength = (int)reader.ReadUInt32();
                    break;
                default:
                    throw new NotImplementedException();
            }
            return new RecordType(new string(header));
        }

        public static RecordType ReadNextRecordType(
            BinaryReader reader,
            out int contentLength)
        {
            return ReadNextRecordType(
                reader,
                Constants.RECORD_LENGTHLENGTH,
                out contentLength);
        }

        public static RecordType ReadNextSubRecordType(
            BinaryReader reader,
            out int contentLength)
        {
            return ReadNextRecordType(
                reader,
                Constants.SUBRECORD_LENGTHLENGTH,
                out contentLength);
        }

        public static RecordType GetNextSubRecordType(
            BinaryReader reader,
            out int contentLength)
        {
            var ret = ReadNextRecordType(
                reader,
                Constants.SUBRECORD_LENGTHLENGTH,
                out contentLength);
            reader.BaseStream.Position -= Constants.SUBRECORD_LENGTH;
            return ret;
        }
    }
}