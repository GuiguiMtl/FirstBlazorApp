using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FirstBlazorApp.Client
{
    public static class FileUtil
    {
        public static Task SaveAs(IJSRuntime js, string filename, byte[] data)
        {
            return js.InvokeAsync<object>("saveAsFile", filename, Convert.ToBase64String(data));
        }
    }
}
