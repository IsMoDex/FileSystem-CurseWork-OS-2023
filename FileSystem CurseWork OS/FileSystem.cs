﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem_CurseWork_OS
{
    class FileSystem
    {
        public string _path = "FS.data";
        public FileSystem()
        {
            //File.Delete(_path);

            if (File.Exists(_path))
            {

                using (FileStream fs = new FileStream(_path, FileMode.Open))
                {
                    DataOperatorFS.ReadSuperBlock(fs);
                }

                using (FileStream fs = new FileStream(_path, FileMode.Open))
                {
                    //int pos = DataOperatorFS.SuperBlock.EndByte;

                    //fs.Seek(pos - 1, SeekOrigin.Begin);

                    byte[] bytes = Encoding.UTF8.GetBytes("A");

                    //fs.Write(bytes, 0, bytes.Length);

                    //Console.WriteLine(Encoding.UTF8.GetString(bytes, 0, bytes.Length));



                    fs.Seek(DataOperatorFS.BitMapTableInodes.StartByte - 1, SeekOrigin.Begin);

                    bytes = Encoding.UTF8.GetBytes("B");

                    fs.Write(bytes, 0, bytes.Length);

                    Console.WriteLine(Encoding.UTF8.GetString(bytes, 0, bytes.Length));



                    fs.Seek(DataOperatorFS.BitMapTableInodes.EndByte - 1, SeekOrigin.Begin);

                    bytes = Encoding.UTF8.GetBytes("C");

                    fs.Write(bytes, 0, bytes.Length);

                    Console.WriteLine(Encoding.UTF8.GetString(bytes, 0, bytes.Length));



                    fs.Seek(DataOperatorFS.TableInodes.StartByte - 1, SeekOrigin.Begin);

                    bytes = Encoding.UTF8.GetBytes("D");

                    fs.Write(bytes, 0, bytes.Length);

                    Console.WriteLine(Encoding.UTF8.GetString(bytes, 0, bytes.Length));



                    fs.Seek(DataOperatorFS.TableInodes.EndByte - 1, SeekOrigin.Begin);

                    bytes = Encoding.UTF8.GetBytes("E");

                    fs.Write(bytes, 0, bytes.Length);

                    Console.WriteLine(Encoding.UTF8.GetString(bytes, 0, bytes.Length));



                    fs.Seek(DataOperatorFS.BitMapDataClasters.StartByte - 1, SeekOrigin.Begin);

                    bytes = Encoding.UTF8.GetBytes("F");

                    fs.Write(bytes, 0, bytes.Length);

                    Console.WriteLine(Encoding.UTF8.GetString(bytes, 0, bytes.Length));



                    fs.Seek(DataOperatorFS.BitMapDataClasters.EndByte - 1, SeekOrigin.Begin);

                    bytes = Encoding.UTF8.GetBytes("G");

                    fs.Write(bytes, 0, bytes.Length);

                    Console.WriteLine(Encoding.UTF8.GetString(bytes, 0, bytes.Length));



                    fs.Seek(DataOperatorFS.DataClasters.StartByte - 1, SeekOrigin.Begin);

                    bytes = Encoding.UTF8.GetBytes("Q");

                    fs.Write(bytes, 0, bytes.Length);

                    Console.WriteLine(Encoding.UTF8.GetString(bytes, 0, bytes.Length));



                    fs.Seek(DataOperatorFS.DataClasters.EndByte - 1, SeekOrigin.Begin);

                    bytes = Encoding.UTF8.GetBytes("R");

                    fs.Write(bytes, 0, bytes.Length);

                    Console.WriteLine(Encoding.UTF8.GetString(bytes, 0, bytes.Length));
                }
                
                
            }
            else
            {
                using (FileStream fs = new FileStream(_path, FileMode.Create))
                {
                    for(long i = 0; i < DataOperatorFS.SuperBlock.CountSectors * DataOperatorFS.SuperBlock.SizeSector; ++i)
                    {
                        fs.WriteByte(0);
                    }

                    DataOperatorFS.WriteSuperBlock(fs);
                    //DataOperatorFS.WriteTableInodes(fs);
                }
            }

            
        }

        //sealed class SuperBlock  //BIOS PARAMETER BLOCK
        //{
        //    public static string NameFileSystem = "TryFS";  //Название файловой системы
        //    public static byte SizeSector = 255;            //Размер сектора
        //    public static ulong SizeFileSystem = 2550000000;//Размер файловой системы
        //    public static ulong SizeRootDirectory = 0;      //Размер корневого каталога
        //    public static byte OffsetToFATTable = 0;        //Смещение к таблице FAT
        //    //public static byte OffsetToCopeFATTable = 4;  //-Смещение к копии таблицы FAT
        //    public static byte OffsetToRootDirectory = 0;   //Смещение к корневому каталогу
        //    public static ulong OffsetToDataArea = 0;       //Смещение к области данных
        //}

        //private void WriteSuperBlock(FileStream fs)
        //{
        //    fs.Write(Encoding.UTF8.GetBytes(SuperBlock.NameFileSystem));        //Название файловой системы
        //    fs.Write(BitConverter.GetBytes(SuperBlock.SizeSector));             //Размер сектора
        //    fs.Write(BitConverter.GetBytes(SuperBlock.SizeFileSystem));         //Размер файловой системы
        //    fs.Write(BitConverter.GetBytes(SuperBlock.SizeRootDirectory));      //Размер корневого каталога
        //    fs.Write(BitConverter.GetBytes(SuperBlock.OffsetToFATTable));       //Смещение к таблице FAT
        //    fs.Write(BitConverter.GetBytes(SuperBlock.OffsetToRootDirectory));  //Смещение к корневому каталогу
        //    fs.Write(BitConverter.GetBytes(SuperBlock.OffsetToDataArea));       //Смещение к области данных
        //}

        //private void ReadSuperBlock(FileStream fs)
        //{
        //    SuperBlock.NameFileSystem = Encoding.UTF8.GetString(ReadBytes(fs, Encoding.UTF8.GetByteCount(SuperBlock.NameFileSystem)));
        //    SuperBlock.SizeSector = ReadByte(fs);
        //    SuperBlock.SizeFileSystem = BitConverter.ToUInt64(ReadBytes(fs, sizeof(ulong)));
        //    SuperBlock.SizeRootDirectory = BitConverter.ToUInt64(ReadBytes(fs, sizeof(ulong)));
        //    SuperBlock.OffsetToFATTable = ReadByte(fs);
        //    SuperBlock.OffsetToRootDirectory = ReadByte(fs);
        //    SuperBlock.OffsetToDataArea = BitConverter.ToUInt64(ReadBytes(fs, sizeof(ulong)));
        //}

        //private byte ReadByte(FileStream fs)
        //{
        //    byte[] buffer = new byte[sizeof(byte)];
        //    fs.Read(buffer, 0, buffer.Length);
        //    return buffer[0];
        //}

        //private byte[] ReadBytes(FileStream fs, int Count)
        //{
        //    byte[] buffer = new byte[Count];
        //    fs.Read(buffer, 0, Count);
        //    return buffer;
        //}



    }
}