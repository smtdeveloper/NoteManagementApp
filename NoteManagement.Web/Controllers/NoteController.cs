using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NoteManagement.Core.DTOs.GenericDTO;
using NoteManagement.Core.DTOs;
using NoteManagement.Core.DTOs.Note;
using NoteManagement.Core.Models;
using System.Net;
using System.Text;
using static Azure.Core.HttpHeader;

namespace NoteManagement.Web.Controllers
{
    public class NoteController : Controller
    {
       

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var response = await client.GetAsync("https://localhost:7229/api/notes/getall");
            
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var jsonObject = JObject.Parse(content);
                var noteList = JsonConvert.DeserializeObject<List<NoteDto>>(jsonObject["data"].ToString());
                return View(noteList);
            }

           return View(null);

        }

        public  async Task<IActionResult> Detail(int id) 
        {
            var client = new HttpClient();
            var response = await client.GetAsync($"https://localhost:7229/api/notes/getbyid/{id}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var jsonObject = JObject.Parse(content);
                var note = JsonConvert.DeserializeObject<NoteDto>(jsonObject["data"].ToString());
                return View(note);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult Save() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(NoteDto noteDto) 
        {
            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(noteDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7229/api/notes/save", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }

       
        public async Task<IActionResult> Remove(int id) 
        {
            var client = new HttpClient();
            var response = await client.DeleteAsync($"https://localhost:7229/api/notes/remove/{id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return NotFound();
            }
            else
            {
                return View("Error");
            }

        }


        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {

            var client = new HttpClient();
            var response = await client.GetAsync($"https://localhost:7229/api/notes/getbyid/{id}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var jsonObject = JObject.Parse(content);
                var note = JsonConvert.DeserializeObject<NoteUpdateDto>(jsonObject["data"].ToString());
                return View(note);
            }
            else
            {
                return NotFound();
            }

        }



        [HttpPost]
        public async Task<IActionResult> Update(NoteUpdateDto noteUpdateDto)
        {

            var client = new HttpClient();
            var json = JsonConvert.SerializeObject(noteUpdateDto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7229/api/notes/update", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return NotFound();
            }
            else
            {
                return View("Error");
            }

        }


    }
}
