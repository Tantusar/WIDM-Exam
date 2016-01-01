Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

Public NotInheritable Class Simple3DES
    Private ReadOnly TripleDes As New TripleDESCryptoServiceProvider

    Private Function TruncateHash(
                                  key As String,
                                  length As Integer) As Byte()
        Dim sha1 As New SHA1CryptoServiceProvider
        Dim keyBytes() As Byte =
                Encoding.Unicode.GetBytes(key)
        Dim hash() As Byte = sha1.ComputeHash(keyBytes)
        ReDim Preserve hash(length - 1)
        Return hash
    End Function

    Sub New(key As String)
        TripleDes.Key = TruncateHash(key, TripleDes.KeySize\8)
        TripleDes.IV = TruncateHash("", TripleDes.BlockSize\8)
    End Sub

    Public Function EncryptData(
                                plaintext As String) As String

        ' Convert the plaintext string to a byte array.
        Dim plaintextBytes() As Byte =
                Encoding.Unicode.GetBytes(plaintext)

        ' Create the stream.
        Dim ms As New MemoryStream
        ' Create the encoder to write to the stream.
        Dim encStream As New CryptoStream(ms,
                                          TripleDes.CreateEncryptor(),
                                          CryptoStreamMode.Write)

        ' Use the crypto stream to write the byte array to the stream.
        encStream.Write(plaintextBytes, 0, plaintextBytes.Length)
        encStream.FlushFinalBlock()

        ' Convert the encrypted stream to a printable string.
        Return Convert.ToBase64String(ms.ToArray)
    End Function

    Public Function DecryptData(
                                encryptedtext As String) As String

        ' Convert the encrypted text string to a byte array.
        Dim encryptedBytes() As Byte = Convert.FromBase64String(encryptedtext)

        ' Create the stream.
        Dim ms As New MemoryStream
        ' Create the decoder to write to the stream.
        Dim decStream As New CryptoStream(ms,
                                          TripleDes.CreateDecryptor(),
                                          CryptoStreamMode.Write)

        ' Use the crypto stream to write the byte array to the stream.
        decStream.Write(encryptedBytes, 0, encryptedBytes.Length)
        decStream.FlushFinalBlock()

        ' Convert the plaintext stream to a string.
        Return Encoding.Unicode.GetString(ms.ToArray)
    End Function
End Class