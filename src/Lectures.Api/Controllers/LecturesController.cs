using Lectures.Api.Contracts;
using Microsoft.AspNetCore.Mvc;
using Lectures.Api.Domain;
using Lectures.Api.Infrastructure;

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
}