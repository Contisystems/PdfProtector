using iTextSharp.text.pdf;
using System.Text;

namespace PdfProtector
{
    internal class PDF
    {
        public static string Protect(string inFolder, string outFolder, string filename, bool closePDF, string ownerPassword)
        {
            var source = Path.Combine(inFolder, filename);
            var destination = Path.Combine(outFolder, filename);

            if (closePDF)
            {
                try
                {
                    using var reader = new PdfReader(source);
                    PdfReader.unethicalreading = true;
                    using var fs = new FileStream(destination, FileMode.Create);
                    PdfEncryptor.Encrypt(
                        reader,
                        fs,
                        null,
                        Encoding.UTF8.GetBytes(ownerPassword),
                        PdfWriter.ALLOW_PRINTING,
                        PdfWriter.STRENGTH40BITS
                    );
                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                try
                {
                    var fi = new FileInfo(source);
                    fi.MoveTo(destination);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return destination;
        }
    }
}
