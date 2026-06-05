namespace Lectures.Api.Contracts;

public class CreateLectureRequest
{
    public Guid CourseId { get; init; }
    public Guid VideoFileId { get; init; }
    public string Title { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
}