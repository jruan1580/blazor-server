using Microsoft.JSInterop;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace OnlineShop.Services
{
    public interface ILocalStorageService
    {
        Task<T> GetItem<T>(string key);
        Task RemoveItem(string key);
        Task SetItem(string key, string value);
    }

    public class LocalStorageService : ILocalStorageService
    {
        private readonly IJSRuntime _jsRunTime;
        public LocalStorageService(IJSRuntime jSRuntime)
        {
            _jsRunTime = jSRuntime;
        }

        public async Task<T> GetItem<T>(string key)
        {
            var json = await _jsRunTime.InvokeAsync<string>("localStorage.getItem", key);

            if (json == null)
            {
                return default;
            }

            return JsonConvert.DeserializeObject<T>(json);
        }

        public async Task SetItem(string key, string value)
        {
            await _jsRunTime.InvokeVoidAsync("localStorage.setItem", key, value);
        }

        public async Task RemoveItem(string key)
        {
            await _jsRunTime.InvokeVoidAsync("localStorage.removeItem", key);
        }
    }
}
