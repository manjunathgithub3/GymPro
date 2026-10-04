using GymPro.Domain.Enums;

namespace GymPro.Contracts.Requests;

public class UpdateInquiryStatusRequest
{
    public InquiryStatus Status { get; set; }
}
