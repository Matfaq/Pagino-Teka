using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Pagino_Teka.Services
{
    public class TranslateService
    {
        private static readonly HttpClient _client = new HttpClient();

        // Lingva API (np. https://lingva.ml/api/v1/{from}/{to}/{text})
        public async Task<string> TranslateLingvaAsync(string text, string from, string to)
        {
            string url = $"https://lingva.ml/api/v1/{from}/{to}/{Uri.EscapeDataString(text)}";
            var response = await _client.GetAsync(url);
            if (!response.IsSuccessStatusCode)
                return text;

            var json = await response.Content.ReadAsStringAsync();
            try
            {
                using var doc = JsonDocument.Parse(json);
                if (doc.RootElement.TryGetProperty("translation", out var translated))
                    return translated.GetString() ?? text;
            }
            catch { }
            return text;
        }

        // MyMemory API (https://api.mymemory.translated.net/get?q={text}&langpair={from}|{to})
        public async Task<string> TranslateMyMemoryAsync(string text, string from, string to)
        {
            string url = $"https://api.mymemory.translated.net/get?q={Uri.EscapeDataString(text)}&langpair={from}|{to}";
            var response = await _client.GetAsync(url);
            if (!response.IsSuccessStatusCode)
                return text;

            var json = await response.Content.ReadAsStringAsync();
            try
            {
                using var doc = JsonDocument.Parse(json);
                if (doc.RootElement.TryGetProperty("responseData", out var data) &&
                    data.TryGetProperty("translatedText", out var translated))
                    return translated.GetString() ?? text;
            }
            catch { }
            return text;
        }

        // Wybiera dostępny serwis (Lingva, potem MyMemory)
        public async Task<string> TranslateAsync(string text, string from, string to)
        {
            var lingva = await TranslateLingvaAsync(text, from, to);
            if (!string.IsNullOrWhiteSpace(lingva) && lingva != text)
                return lingva;

            var myMemory = await TranslateMyMemoryAsync(text, from, to);
            return !string.IsNullOrWhiteSpace(myMemory) ? myMemory : text;
        }
    }
}