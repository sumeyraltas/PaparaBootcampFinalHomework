using Models.Shared.ResponseDto;
using PaparaBootcampFinalHomework.Models.Tokens.DTOs;

namespace PaparaBootcampFinalHomework.Models.Tokens
{
    public interface ITokenService
    {
      Task<ResponseDto<TokenCreateResponseDto>> Create(TokenCreateRequestDTO request);
    }
}
