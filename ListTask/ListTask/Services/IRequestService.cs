using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ListTask.Services
{
    public interface IRequestService
    {
        public Task<string> GetAsync(string uri);

        public Task<string> PostAsync(string uri, string data);

        public Task<string> DeleteAsync(string uri, string data);
    }
}
