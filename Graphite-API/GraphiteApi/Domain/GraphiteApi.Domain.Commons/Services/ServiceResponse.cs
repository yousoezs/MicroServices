namespace GraphiteApi.Domain.Commons.Services;

public record ServiceResponse<T>(bool Success, T? Data, string Message);
