﻿using DSInternals.Common;
using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security.AccessControl;

namespace DSInternals.DataStore.Test
{
    [TestClass]
    public class SecurityDescriptorResolverTester
    {
        [TestMethod]
        public void SecurityDescriptorResolver_ComputeHash_W2016_Vector1()
        {
            byte[] binarySecurityDescriptor = "01001480e802000004030000140000009400000004008000040000000240140020000c0001010000000000010000000002401800000100000102000000000005200000002002000002402400000100000105000000000005150000004dfc5019daac02ace33e5bc6010200000740280000010000010000005651ec457edbbb47b53fdbeb2d03c40f010100000000000100000000040054020f000000050028000001000001000000aaf63111079cd111f79f00c04fc2dcd2010100000000000509000000050028000001000001000000abf63111079cd111f79f00c04fc2dcd2010100000000000509000000050028000001000001000000acf63111079cd111f79f00c04fc2dcd201010000000000050900000005002c000001000001000000aaf63111079cd111f79f00c04fc2dcd20102000000000005200000002002000005002c000001000001000000abf63111079cd111f79f00c04fc2dcd20102000000000005200000002002000005002c000001000001000000acf63111079cd111f79f00c04fc2dcd201020000000000052000000020020000000014009400020001010000000000050b00000000022400ff010f000105000000000005150000004dfc5019daac02ace33e5bc60702000000001400ff010f00010100000000000512000000000a2400bd010f000105000000000005150000004dfc5019daac02ae33e5bc600020000050028000001000001000000adf63111079cd111f79f00c04fc2dcd2010100000000000509000000050028000001000001000000765be9894d44624c991a0facbeda640c01010000000000050900000005002c000001000001000000adf63111079cd111f79f00c04fc2dcd20102000000000005200000002002000005002c000001000001000000765be9894d44624c991a0facbeda640c01020000000000052000000020020000050038000001000001000000aaf63111079cd111f79f00c04fc2dcd20105000000000005150000004dfc5019daac02ace33e5bc6f20100000105000000000005150000004dfc5019daac02ace33e5bc6070200000105000000000005150000004dfc5019daac02ace33e5bc607020000".HexToBinary();
            byte[] expectedHash = "1d5459903a7daca3926c0c4e09b26fe8".HexToBinary();

            var securityDescriptor = new CommonSecurityDescriptor(true, false, binarySecurityDescriptor, 0);
            byte[] hash = SecurityDescriptorRersolver.ComputeHash(securityDescriptor);
            Assert.AreEqual(true, expectedHash.SequenceEqual(hash));
        }

        [TestMethod]
        public void SecurityDescriptorResolver_ComputeHash_W2016_Vector2()
        {
            byte[] binarySecurityDescriptor = "0f00000001000480300000003c000000000000001400000002001c000100000000031400ffffffff010100000000000100000000010100000000000100000000010100000000000100000000".HexToBinary();
            byte[] expectedHash = "5763e6665429964b143bb464463bf068".HexToBinary();

            var securityDescriptor = new CommonSecurityDescriptor(true, true, binarySecurityDescriptor, 0);
            byte[] hash = SecurityDescriptorRersolver.ComputeHash(securityDescriptor);
            Assert.AreEqual(true, expectedHash.SequenceEqual(hash));
        }
    }
}
