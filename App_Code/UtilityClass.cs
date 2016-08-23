using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Security.Cryptography;
using System.Configuration;
using System.Drawing;
using System.Data;
using AspMap;

/// <summary>
/// Summary description for UtilityClass
/// </summary>


public static class UtilityClass
{
    public static string ConnectionString()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("user id=");
        sb.Append(ConfigurationManager.AppSettings["DatabaseUser"].ToString());
        sb.Append(";password=");
        sb.Append(ConfigurationManager.AppSettings["DatabasePassword"].ToString());
        sb.Append(";host=");
        sb.Append(ConfigurationManager.AppSettings["DatabaseHost"].ToString());
        sb.Append(";port=");
        sb.Append(ConfigurationManager.AppSettings["DatabasePort"].ToString());
        sb.Append(";database=");
        sb.Append(ConfigurationManager.AppSettings["DatabaseName"].ToString());
        //sb.Append(";pooling=true;min pool size=0;max pool size=100;connection lifetime=0");
        sb.Append(";");
        return sb.ToString();
    }

    public static bool UseGoogleMapKey()
    {
        return ConfigurationManager.AppSettings["UseGoogleMapKey"].ToString().Equals("1") ? true : false;
    }

    public static string GoogleMapKey()
    {
        return ConfigurationManager.AppSettings["GoogleMapKey"].ToString();
    }

    public static string GetLiveLink()
    {
        return ConfigurationManager.AppSettings["LiveLink"].ToString();
    }

    public static string GetSmsPort()
    {
        return ConfigurationManager.AppSettings["SmsPort"].ToString();
    }

    public static string EncryptString(string Message)
    {
        byte[] Results;
        System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
        // Step 1. We hash the passphrase using MD5
        // We use the MD5 hash generator as the result is a 128 bit byte array
        // which is a valid length for the TripleDES encoder we use below
        MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
        byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(GetPasswordPhrase()));
        // Step 2. Create a new TripleDESCryptoServiceProvider object
        TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();
        // Step 3. Setup the encoder
        TDESAlgorithm.Key = TDESKey;
        TDESAlgorithm.Mode = CipherMode.ECB;
        TDESAlgorithm.Padding = PaddingMode.PKCS7;
        // Step 4. Convert the input string to a byte[]
        byte[] DataToEncrypt = UTF8.GetBytes(Message);
        // Step 5. Attempt to encrypt the string
        try
        {
            ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
            Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
        }
        finally
        {
            // Clear the TripleDes and Hashprovider services of any sensitive information
            TDESAlgorithm.Clear();
            HashProvider.Clear();
        }
        // Step 6. Return the encrypted string as a base64 encoded string
        return Convert.ToBase64String(Results);
    }

    public static string DecryptString(string Message)
    {
        byte[] Results;
        System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
        // Step 1. We hash the passphrase using MD5
        // We use the MD5 hash generator as the result is a 128 bit byte array
        // which is a valid length for the TripleDES encoder we use below
        MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
        byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(GetPasswordPhrase()));
        // Step 2. Create a new TripleDESCryptoServiceProvider object
        TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();
        // Step 3. Setup the decoder
        TDESAlgorithm.Key = TDESKey;
        TDESAlgorithm.Mode = CipherMode.ECB;
        TDESAlgorithm.Padding = PaddingMode.PKCS7;
        // Step 4. Convert the input string to a byte[]
        byte[] DataToDecrypt = Convert.FromBase64String(Message);
        // Step 5. Attempt to decrypt the string
        try
        {
            ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
            Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
        }
        finally
        {
            // Clear the TripleDes and Hashprovider services of any sensitive information
            TDESAlgorithm.Clear();
            HashProvider.Clear();
        }
        // Step 6. Return the decrypted string in UTF8 format
        return UTF8.GetString(Results);
    }

    public static string GetPasswordPhrase()
    {
        string tmpStr = "CEIP_BETS_KPA";
        string retVal = string.Empty;

        for (int i = tmpStr.Length; i > 0; i--)
        {
            retVal = retVal + tmpStr[i - 1].ToString();
        }
        return retVal;
    }

    public static string ConvASCII2UNICODE(string asciiString)
    {
        asciiString = asciiString.Replace("0", "০");
        asciiString = asciiString.Replace("1", "১");
        asciiString = asciiString.Replace("2", "২");
        asciiString = asciiString.Replace("3", "৩");
        asciiString = asciiString.Replace("4", "৪");
        asciiString = asciiString.Replace("5", "৫");
        asciiString = asciiString.Replace("6", "৬");
        asciiString = asciiString.Replace("7", "৭");
        asciiString = asciiString.Replace("8", "৮");
        asciiString = asciiString.Replace("9", "৯");
        asciiString = asciiString.Replace(".", ".");

        return asciiString;
    }

    public static string ConvUNICODE2ASCII(string unicodeString)
    {
        unicodeString = unicodeString.Replace("০", "0");
        unicodeString = unicodeString.Replace("১", "1");
        unicodeString = unicodeString.Replace("২", "2");
        unicodeString = unicodeString.Replace("৩", "3");
        unicodeString = unicodeString.Replace("৪", "4");
        unicodeString = unicodeString.Replace("৫", "5");
        unicodeString = unicodeString.Replace("৬", "6");
        unicodeString = unicodeString.Replace("৭", "7");
        unicodeString = unicodeString.Replace("৮", "8");
        unicodeString = unicodeString.Replace("৯", "9");
        unicodeString = unicodeString.Replace(".", ".");
        /*
        double retVal=0;
        try
        {
            retVal = double.Parse(unicodeString);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine(ex.Message); 
        }
        */
        return unicodeString;
    }

    public static Color GetColorFromHex(string hex)
    {
        int red = 0;
        int green = 0;
        int blue = 0;

        if (hex.Length == 6)
        {
            red = Convert.ToInt32(hex.Substring(0, 2), 16);
            green = Convert.ToInt32(hex.Substring(2, 2), 16);
            blue = Convert.ToInt32(hex.Substring(4, 2), 16);
        }


        return Color.FromArgb(red, green, blue);
    }

    public static Color GetColorFromRGB(string rgbColorValue)
    {
        int red = 0;
        int green = 0;
        int blue = 0;
        int fIdx = 0;
        int lIdx = 0;
        fIdx = rgbColorValue.IndexOf(",");
        lIdx = rgbColorValue.LastIndexOf(",");
        if (rgbColorValue.Length > 0)
        {
            red = Convert.ToInt32(rgbColorValue.Substring(0, fIdx));
            green = Convert.ToInt32(rgbColorValue.Substring(fIdx + 1, lIdx - fIdx - 1));
            blue = Convert.ToInt32(rgbColorValue.Substring(lIdx + 1, rgbColorValue.Length - lIdx - 1));
        }
        return Color.FromArgb(red, green, blue);
    }

    public static PointStyle GetPointStyle(string pointName)
    {
        PointStyle ps = PointStyle.Triangle;
        switch (pointName.ToLower())
        {
            case "arrow":
                ps = PointStyle.Arrow;
                break;
            case "bitmap":
                ps = PointStyle.Triangle;
                break;
            case "circle":
                ps = PointStyle.Circle;
                break;
            case "circlewithlargecenter":
                ps = PointStyle.CircleWithLargeCenter;
                break;
            case "circlewithsmallcenter":
                ps = PointStyle.CircleWithSmallCenter;
                break;
            case "cross":
                ps = PointStyle.Cross;
                break;
            case "font":
                ps = PointStyle.Font;
                break;
            case "rhomb":
                ps = PointStyle.Rhomb;
                break;
            case "square":
                ps = PointStyle.Square;
                break;
            case "squarewithlargecenter":
                ps = PointStyle.SquareWithLargeCenter;
                break;
            case "squarewithsmallcenter":
                ps = PointStyle.SquareWithSmallCenter;
                break;
            case "star":
                ps = PointStyle.Star;
                break;
            case "triangle":
                ps = PointStyle.Triangle;
                break;
        }

        return ps;
    }

    public static LineStyle GetLineStyle(string lineName)
    {
        LineStyle ls = LineStyle.Solid;
        switch (lineName.ToLower())
        {
            case "arrowboth":
                ls = LineStyle.ArrowBoth;
                break;
            case "arrowend":
                ls = LineStyle.ArrowEnd;
                break;
            case "arrowstart":
                ls = LineStyle.ArrowStart;
                break;
            case "dualroad":
                ls = LineStyle.DualRoad;
                break;
            case "dashdotdotroad":
                ls = LineStyle.DashDotDotRoad;
                break;
            case "dashdotroad":
                ls = LineStyle.DashDotRoad;
                break;
            case "dotroad":
                ls = LineStyle.DotRoad;
                break;
            case "dashroad":
                ls = LineStyle.DashRoad;
                break;
            case "road":
                ls = LineStyle.Road;
                break;
            case "railroad":
                ls = LineStyle.Railroad;
                break;
            case "dashdotdot":
                ls = LineStyle.DashDotDot;
                break;
            case "dashdot":
                ls = LineStyle.DashDot;
                break;
            case "dot":
                ls = LineStyle.Dot;
                break;
            case "dash":
                ls = LineStyle.Dash;
                break;
            case "solid":
                ls = LineStyle.Solid;
                break;
            case "invisible":
                ls = LineStyle.Invisible;
                break;
            default:
                ls = LineStyle.Solid;
                break;
        }

        return ls;
    }

    public static FillStyle GetFillStyle(string fillName)
    {
        FillStyle fs = FillStyle.Solid;
        switch (fillName.ToLower())
        {
            case "bitmap":
                fs = FillStyle.Bitmap;
                break;
            case "darkgray":
                fs = FillStyle.DarkGray;
                break;
            case "gray":
                fs = FillStyle.Gray;
                break;
            case "lightgray":
                fs = FillStyle.LightGray;
                break;
            case "diagonalcross":
                fs = FillStyle.DiagonalCross;
                break;
            case "cross":
                fs = FillStyle.Cross;
                break;
            case "downwarddiagonal":
                fs = FillStyle.DownwardDiagonal;
                break;
            case "upwarddiagonal":
                fs = FillStyle.UpwardDiagonal;
                break;
            case "vertical":
                fs = FillStyle.Vertical;
                break;
            case "horizontal":
                fs = FillStyle.Horizontal;
                break;
            case "solid":
                fs = FillStyle.Solid;
                break;
            case "invisible":
                fs = FillStyle.Invisible;
                break;
            default:
                fs = FillStyle.Solid;
                break;
        }
        return fs;
    }

    public static string QuarterDate(string year, string quarter)
    {
        string retVal = string.Empty;
        switch (quarter)
        {
            case "Q1":
                retVal = "30-Sep-" + year.Substring(0, 4);
                break;
            case "Q2":
                retVal = "31-Dec-" + year.Substring(0, 4);
                break;
            case "Q3":
                retVal = "31-Mar-" + year.Substring(5, 4);
                break;
            case "Q4":
                retVal = "30-Jun-" + year.Substring(5, 4);
                break;
            default:
                break;
        }

        return retVal;
    }
}