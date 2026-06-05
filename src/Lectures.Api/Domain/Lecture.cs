namespace Lectures.Api.Domain;

public class Lecture
{
    public Guid Id { get; init; }
    public Guid CourseId { get; init; }
    public Guid VideoFileId { get; init; }
    public string Title { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public DateTime CreatedAt { get; init; }
}