using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace mongodb_app
{
    class Unemployment_2019
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("state")]
        public String state { get; set;  }
        [BsonElement("Total Unemployed")]
        public String Total_Unemployed { get; set; }
        [BsonElement("UNEMPLOYMENT RATE")]
        public double unemployment_rate { get; set; }

        public Unemployment_2019(string state, string total_Unemployed, double unemployment_rate)
        {
            this.state = state;
            Total_Unemployed = total_Unemployed;
            this.unemployment_rate = unemployment_rate;
        }
    }
}
