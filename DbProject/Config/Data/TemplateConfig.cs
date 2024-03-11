using System.Diagnostics.CodeAnalysis;

namespace DbProject.Config.Data;


/// <summary>
/// Template config is a sealed record only for creating a template config file.
/// </summary>
[SuppressMessage("ReSharper", "UnusedMember.Global")]
[SuppressMessage("Performance", "CA1822:Mark members as static")]
public sealed record TemplateConfig
{
    public string Host => "localhost";
    public string Username => "root";
    public string Password => "password";
    public short Port => 80;
    public string DbName => "db";
}