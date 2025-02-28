using Microsoft.AspNetCore.Mvc;
using Movies.API.Mapping;
using Movies.Application.Models;
using Movies.Application.Repositories;
using Movies.Contracts.Requests;

namespace Movies.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MoviesController (IMovieRepository movieRepository) : ControllerBase
{
   
    [HttpPost("/create")]
    public async Task<IActionResult> Create(CreateMovieRequest obj)
    {
        var movie = obj.ToMovie();

        await movieRepository.CreateAsync(movie);
        return CreatedAtRoute("getMovieById", new { id = movie.Id }, movie);

    }
    
    [HttpGet("/get/{id:guid}" , Name = "getMovieById")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var movie = await movieRepository.GetByIdAsync(id);
        if (movie is null)
        {
            return NotFound();
        }
        return Ok(movie.ToString());
    }
    [HttpGet("/getAll")]
    public async Task<IActionResult> GetAll()
    {
        var movie = await movieRepository.GetAllAsync();

        return Ok(movie.ToString());
    }
    
    [HttpPost("/update")]
    public async Task<IActionResult> Update( [FromRoute] Guid id , [FromBody] UpdateMovieRequest obj)
    {
        var movie = obj.ToMovie(id);
        var isUpdate = await movieRepository.UpdateAsync(movie);
        if (!isUpdate)
        {
            return BadRequest();
        }

        return Ok();
    }
    
    [HttpPost("/delete")]
    public async Task<IActionResult> Delete( [FromRoute] Guid id )
    {
        var isDeleted = await movieRepository.DeleteByIdAsync(id);
        if (!isDeleted)
        {
            return BadRequest();
        }

        return Ok();
    }

    
}