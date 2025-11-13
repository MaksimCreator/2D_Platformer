using System;
using System.IO;
using System.Text;
using System.Linq;
using UnityEngine;
using System.Collections.Generic;
using System.Security.Cryptography;
using Newtonsoft.Json;

public class SaveLoaderGame : ISaveLoaderGame
{
    private const string EncryptionKey = "c29tZSUyMHRleHQtJDEyMw==";

    private string FilePath => Application.persistentDataPath + "gameState.dat";

    public void Save(Dictionary<string, object> gameState)
    {
        Type[] SerializeObjectsType = gameState.Values.Select(value => value.GetType()).ToArray();
        ValidateUniqueNames(SerializeObjectsType);

        string jsonData = JsonConvert.SerializeObject(gameState);
        byte[] data = Encoding.UTF8.GetBytes(jsonData);

        byte[] encryptedData = Encrypt(data, EncryptionKey);

        File.WriteAllBytes(FilePath, encryptedData);
    }

    public void Load(out Dictionary<string, object> data)
    {
        string filePath = FilePath;
        data = new();

        if (File.Exists(filePath) == false)
            return;

        JsonSerializerSettings settings = new JsonSerializerSettings
        {
            PreserveReferencesHandling = PreserveReferencesHandling.Objects,
            ReferenceLoopHandling = ReferenceLoopHandling.Serialize
        };
        JsonSerializer serializer = JsonSerializer.Create(settings);


        byte[] encryptedDataHashed = File.ReadAllBytes(filePath);
        byte[] decryptedData = Decrypt(encryptedDataHashed, EncryptionKey);

        string jsonData = Encoding.UTF8.GetString(decryptedData);

        data = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonData);
    }

    private byte[] Encrypt(byte[] data, string key)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = Convert.FromBase64String(key);
            aes.GenerateIV(); // Генерация нового вектора инициализации

            using (MemoryStream ms = new MemoryStream())
            {
                ms.Write(aes.IV, 0, aes.IV.Length); // Сохранение IV в начало потока
                using (CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(data, 0, data.Length);
                }
                return ms.ToArray();
            }
        }
    }

    private byte[] Decrypt(byte[] data, string key)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = Convert.FromBase64String(key);
            byte[] iv = new byte[aes.BlockSize / 8];
            Array.Copy(data, 0, iv, 0, iv.Length);

            aes.IV = iv;

            using (MemoryStream ms = new MemoryStream(data, iv.Length, data.Length - iv.Length))
            {
                using (CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    using (MemoryStream decryptedStream = new MemoryStream())
                    {
                        cs.CopyTo(decryptedStream);
                        return decryptedStream.ToArray();
                    }
                }
            }
        }
    }

    private void ValidateUniqueNames(Type[] types)
    {
        for (int i = 0; i < types.Length; i++)
        {
            for (int y = 0; y < types.Length; y++)
            {
                if (i == y)
                    continue;

                if (types[i].Name == types[y].Name)
                    throw new InvalidOperationException("Exeption system.The types should not be repeated");
            }
        }
    }
}