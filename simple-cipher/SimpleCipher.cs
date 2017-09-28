using System;
using System.Text.RegularExpressions;
using System.Linq;

public class Cipher
{
    public Cipher()
    {
        string key = string.Empty;
        for (int i = 0; i < 100; i++)
        {
            key += (char)rand.Next('a', 'z');
        }
        _key = key;
    }

    public Cipher(string key)
    {
        if (!Regex.IsMatch(key, @"^[a-z]+$"))
        {
            throw new ArgumentException();
        }
        _key = key;
    }

    static Random rand = new Random();
    readonly string _key;

    public string Key
    {
        get
        {
            return _key;
        }
    }

    public string Encode(string plaintext)
    {
        string encoded = string.Empty;
        for (int i = 0; i < plaintext.Length; i++)
        {
            encoded += (char)((plaintext[i] + Key[i] - 'a' * 2) % 26 + 'a');
        }
        return encoded;
    }

    public string Decode(string ciphertext)
    {
        string decoded = string.Empty;
        for (int i = 0; i < ciphertext.Length; i++)
        {
            decoded += (char)(mod((ciphertext[i] - Key[i]), 26) + 'a');
        }
        return decoded;
    }

    int mod(int a, int b) => (a % b + b) % b;
}