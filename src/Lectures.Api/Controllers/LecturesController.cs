using Lectures.Api.Contracts;
using Microsoft.AspNetCore.Mvc;
using Lectures.Api.Domain;
using Lectures.Api.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Lectures.Api.Controllers;

[ApiController]
[Route("api/lectures")]
public class LecturesController(LecturesDbContext dbContext) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateLecture(CreateLectureRequest request, CancellationToken cancellationToken)
    {
        var lecture = new Lecture
        {
            Id = Guid.NewGuid(),
            CourseId = request.CourseId,
            Title = request.Title,
            Description = request.Description,
            VideoFileId = request.VideoFileId,
            CreatedAt = DateTime.UtcNow
        };

        dbContext.Lectures.Add(lecture);
        await dbContext.SaveChangesAsync(cancellationToken);

        return Created($"/api/lectures/{lecture.Id}", lecture);
    }



    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetLecture(Guid id, CancellationToken cancellationToken)
    {
        var lecture = await dbContext.Lectures.FindAsync([id], cancellationToken);

        if (lecture is null)
        {
            return NotFound();
        }

        return Ok(lecture);
    }


    [HttpGet("course/{courseId:guid}")]
    public async Task<IActionResult> GetLecturesByCourse(Guid courseId, CancellationToken cancellationToken)
    {
        var lectures = await dbContext.Lectures.Where(lecture => lecture.CourseId == courseId).ToListAsync(cancellationToken);

        return Ok(lectures);
    }


    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteLecture(Guid id, CancellationToken cancellationToken)
    {
        var lecture = await dbContext.Lectures.FindAsync([id], cancellationToken);

        if (lecture is null)
        {
            return NotFound();
        }

        dbContext.Lectures.Remove(lecture);

        await dbContext.SaveChangesAsync(cancellationToken);

        return NoContent();
    }
}