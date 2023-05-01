using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection;

namespace WebApi.Controllers;
/// <summary>
/// 
/// </summary>
public class MetaController : BaseApiController
{
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpGet("/info")]
    public ActionResult<string> Info()
    {
        Assembly assembly = typeof(Program).Assembly;
        DateTime lastUpdate = System.IO.File.GetLastWriteTime(assembly.Location);
        string? version = FileVersionInfo.GetVersionInfo(assembly.Location).ProductVersion;
        return Ok($"Version: {version}, Last Updated: {lastUpdate}");
    }
}

