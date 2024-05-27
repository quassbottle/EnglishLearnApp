using EnglishApplication.Common.RabbitMQ.Interfaces;
using Microsoft.Extensions.Configuration;

namespace EnglishApplication.Common.RabbitMQ;

public class RabbitMqSettings(IConfiguration configuration) : IRabbitMqSettings
{
    public string Host
    {
        get
        {
            var section = configuration.GetSection("RabbitMq");

            if (section["Host"] is null) throw new ArgumentException("Invalid RabbitMq Host");

            return section["Host"]!;
        }
    }

    public string User
    {
        get
        {
            var section = configuration.GetSection("RabbitMq");

            if (section["User"] is null) throw new ArgumentException("Invalid RabbitMq User");

            return section["User"]!;
        }
    }

    public string Password
    {
        get
        {
            var section = configuration.GetSection("RabbitMq");

            if (section["Password"] is null) throw new ArgumentException("Invalid RabbitMq Password");

            return section["Password"]!;
        }
    }

    public int Port
    {
        get
        {
            var section = configuration.GetSection("RabbitMq");

            if (section["Port"] is null) throw new ArgumentException("Invalid RabbitMq Port");

            return int.Parse(section["Port"]!);
        }
    }
}