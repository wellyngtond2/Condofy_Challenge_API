using System.IO;
using System.Threading.Tasks;

namespace condofy_challenge_API.Shared.Functions
{
    public static class ByteFunctions
    {
        public async static Task<byte[]> ConverteStreamToByteArray(Stream stream)
        {
            if (stream == null)
                return new byte[0];

            if (stream.Length == 0)
                return new byte[0];

            byte[] byteArray = new byte[16 * 1024];
            using (MemoryStream mStream = new MemoryStream())
            {
                int bit;
                while ((bit = await stream.ReadAsync(byteArray, 0, byteArray.Length)) > 0)
                {
                   await mStream.WriteAsync(byteArray, 0, bit);
                }
                return mStream.ToArray();
            }
        }
    }
}
