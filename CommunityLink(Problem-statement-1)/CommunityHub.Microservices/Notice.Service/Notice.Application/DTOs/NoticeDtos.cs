using System;

namespace Notice.Application.DTOs
{
    public record NoticeDto(Guid Id, string Title, string Description, string PostedBy, DateTime CreatedDate);
    public record CreateNoticeRequest(string Title, string Description, string PostedBy);
    public record UpdateNoticeRequest(string Title, string Description);
}
