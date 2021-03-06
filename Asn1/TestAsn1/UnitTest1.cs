using Microsoft.VisualStudio.TestTools.UnitTesting;
using Asn1;

namespace TestAsn1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDecodeBER()
        {
            // Arrange (Use a Kerberos AS_REQ buffer).
            var kerberos_as_req = new byte[]
            {
                0x6a, 0x82, 0x01, 0x1f, 0x30, 0x82, 0x01, 0x1b, 0xa1, 0x03, 0x02, 0x01, 0x05, 0xa2, 0x03, 0x02,
                0x01, 0x0a, 0xa3, 0x5f, 0x30, 0x5d, 0x30, 0x48, 0xa1, 0x03, 0x02, 0x01, 0x02, 0xa2, 0x41, 0x04,
                0x3f, 0x30, 0x3d, 0xa0, 0x03, 0x02, 0x01, 0x17, 0xa2, 0x36, 0x04, 0x34, 0x09, 0xa2, 0x24, 0x48,
                0x93, 0xaf, 0xf5, 0xf3, 0x84, 0xf7, 0x9c, 0x37, 0x88, 0x3f, 0x15, 0x4a, 0x32, 0xd3, 0x96, 0xa9,
                0x14, 0xa4, 0xd0, 0xa7, 0x8e, 0x97, 0x9b, 0xa7, 0x5d, 0x4f, 0xf5, 0x3c, 0x1d, 0xb7, 0x29, 0x41,
                0x41, 0x76, 0x0f, 0xee, 0x05, 0xe4, 0x34, 0xc1, 0x2e, 0xcf, 0x8d, 0x5b, 0x9a, 0xa5, 0x83, 0x9e,
                0x30, 0x11, 0xa1, 0x04, 0x02, 0x02, 0x00, 0x80, 0xa2, 0x09, 0x04, 0x07, 0x30, 0x05, 0xa0, 0x03,
                0x01, 0x01, 0xff, 0xa4, 0x81, 0xad, 0x30, 0x81, 0xaa, 0xa0, 0x07, 0x03, 0x05, 0x00, 0x40, 0x81,
                0x00, 0x10, 0xa1, 0x10, 0x30, 0x0e, 0xa0, 0x03, 0x02, 0x01, 0x01, 0xa1, 0x07, 0x30, 0x05, 0x1b,
                0x03, 0x64, 0x65, 0x73, 0xa2, 0x08, 0x1b, 0x06, 0x44, 0x45, 0x4e, 0x59, 0x44, 0x43, 0xa3, 0x1b,
                0x30, 0x19, 0xa0, 0x03, 0x02, 0x01, 0x02, 0xa1, 0x12, 0x30, 0x10, 0x1b, 0x06, 0x6b, 0x72, 0x62,
                0x74, 0x67, 0x74, 0x1b, 0x06, 0x44, 0x45, 0x4e, 0x59, 0x44, 0x43, 0xa5, 0x11, 0x18, 0x0f, 0x32,
                0x30, 0x33, 0x37, 0x30, 0x39, 0x31, 0x33, 0x30, 0x32, 0x34, 0x38, 0x30, 0x35, 0x5a, 0xa6, 0x11,
                0x18, 0x0f, 0x32, 0x30, 0x33, 0x37, 0x30, 0x39, 0x31, 0x33, 0x30, 0x32, 0x34, 0x38, 0x30, 0x35,
                0x5a, 0xa7, 0x06, 0x02, 0x04, 0x0b, 0xc4, 0xdd, 0x7e, 0xa8, 0x19, 0x30, 0x17, 0x02, 0x01, 0x17,
                0x02, 0x02, 0xff, 0x7b, 0x02, 0x01, 0x80, 0x02, 0x01, 0x03, 0x02, 0x01, 0x01, 0x02, 0x01, 0x18,
                0x02, 0x02, 0xff, 0x79, 0xa9, 0x1d, 0x30, 0x1b, 0x30, 0x19, 0xa0, 0x03, 0x02, 0x01, 0x14, 0xa1,
                0x12, 0x04, 0x10, 0x58, 0x50, 0x31, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20, 0x20,
                0x20, 0x20, 0x20
            };

            // Act.
            byte[] ber_data = Asn1.AsnIO.FindBER(kerberos_as_req);
            AsnElt asn_object = AsnElt.Decode(ber_data);

            // Assert
            Assert.IsTrue(asn_object.TagValue == 10);
            Assert.IsTrue(asn_object.Sub.Length == 1);
        }
    }
}
