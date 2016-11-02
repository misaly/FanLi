using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace FanLi.Common
{
    [Serializable]
    public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, IXmlSerializable
    {
        public SerializableDictionary() { }
        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="write"></param>
        public void WriteXml(XmlWriter write)
        {
            foreach (KeyValuePair<TKey, TValue> kv in this)
            {
                //键
                write.WriteStartElement("SerializableDictionary");
                write.WriteStartElement("key");
                new XmlSerializer(typeof(TKey)).Serialize(write, kv.Key);
                write.WriteEndElement();
                //值
                write.WriteStartElement("value");
                new XmlSerializer(typeof(TValue)).Serialize(write, kv.Value);
                write.WriteEndElement();
                write.WriteEndElement();
            }
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <param name="reader"></param>
        public void ReadXml(XmlReader reader)
        {
            //读
            reader.Read();
            while (reader.NodeType != XmlNodeType.EndElement)
            {
                reader.ReadStartElement("SerializableDictionary");
                reader.ReadStartElement("key");
                TKey tk = (TKey)new XmlSerializer(typeof(TKey)).Deserialize(reader);
                reader.ReadEndElement();
                reader.ReadStartElement("value");
                TValue vl = (TValue)new XmlSerializer(typeof(TValue)).Deserialize(reader);
                reader.ReadEndElement();
                reader.ReadEndElement();
                this.Add(tk, vl);
                reader.MoveToContent();
            }
            reader.ReadEndElement();
        }

        /// <summary>
        /// 此方法是保留方法，请不要使用。返回null
        /// </summary>
        /// <returns></returns>
        public XmlSchema GetSchema()
        {
            return null;
        }
    }
}