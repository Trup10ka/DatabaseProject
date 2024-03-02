using System.Diagnostics.CodeAnalysis;

namespace DbProject.Config.Data;


[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("Performance", "CA1822:Mark members as static")]
public record TemplateConfig : IConfig
{
    public string Host => "localhost";
    public string Username => "root";
    public string Password => "password";
    public short Port => 80;
    public string DbName => "db";
}