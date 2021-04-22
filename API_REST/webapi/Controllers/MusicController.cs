using Domain.Models.Entities;
using Domain.Interfaces.Repositories;
using Infra.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Domain.Interfaces.Repository;
using System.Linq.Expressions;
using System;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using RestSharp;

namespace webapi.Controllers
{
    [Route("api/")]
    public class MusicController : Controller
    {
        private readonly IMusicRepository _musicRepository;
        private readonly IGenderRepository _genderRepository;
        private readonly IAuthorRepository _authorRepository;

        public MusicController(IMusicRepository musicRepository,
                               IGenderRepository genderRepository,
                               IAuthorRepository authorRepository)
        {
            _musicRepository = musicRepository;
            _genderRepository = genderRepository;
            _authorRepository = authorRepository;
        }
        
        /// <summary>
        /// Obtem todas as musicas
        /// </summary>   
        /// <returns>Objeto contendo musicas.</returns>  
        [HttpGet("[controller]/v1/GetMusics")]
        public object GetMusics()
        {
            try
            {               
                return StatusCode(200, _musicRepository.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex.StackTrace);
            }
        }

        /// <summary>
        /// Cria uma nova musica        
        /// </summary>
        /// <param name="music">Objeto Musica</param>
        /// <returns>Objeto contendo dados de uma musica.</returns>  
        [HttpPost("[controller]/v1/SaveMusic")]       
        public object SaveMusic([FromBody] Music music)
        {
            try
            {

                music.Author = _authorRepository.GetById(music.Author.CodAuthor);
                music.Gender = _genderRepository.GetById(music.Gender.CodGender);

                return StatusCode(200, _musicRepository.Add(music));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.StackTrace);
            }
        }

        /// <summary>
        /// Alterar uma musica  
        /// </summary>
        /// <param name="music">Objeto Musica</param>
        /// <returns>Objeto contendo dados de uma musica.</returns>  
        [HttpPut("[controller]/v1/EditMusic")]
        public object EditMusic([FromBody] Music music)
        {
            try
            {
                music.Author = _authorRepository.GetById(music.Author.CodAuthor);
                music.Gender = _genderRepository.GetById(music.Gender.CodGender);

                _musicRepository.Update(music);
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.StackTrace);
            }
        }

    }
}


