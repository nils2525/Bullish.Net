using CryptoExchange.Net.RateLimiting.Interfaces;
using System.Net.Http;

namespace CryptoExchange.Net.Objects
{
    internal static class CryptoExchangeNetV12CompatibilityExtensions
    {
        public static void AddOptional(this Parameters parameters, string key, string? value)
            => parameters.Add(key, value);

        public static void AddOptional(this Parameters parameters, string key, int? value)
            => parameters.Add(key, value);

        public static void AddOptional(this Parameters parameters, string key, long? value)
            => parameters.Add(key, value);

        public static void AddOptional(this Parameters parameters, string key, decimal? value)
            => parameters.Add(key, value);

        public static void AddOptional(this Parameters parameters, string key, bool? value)
            => parameters.Add(key, value);

        public static void AddString(this Parameters parameters, string key, decimal value)
            => parameters.Add(key, value);

        public static void AddOptionalString(this Parameters parameters, string key, decimal? value)
            => parameters.Add(key, value);

        public static void AddOptional<T>(this Parameters parameters, string key, T? value)
            where T : struct, Enum
            => parameters.Add(key, value);

        public static void AddOptionalEnum<T>(this Parameters parameters, string key, T? value)
            where T : struct, Enum
            => parameters.Add(key, value);

        public static void AddEnum<T>(this Parameters parameters, string key, T value)
            where T : struct, Enum
            => parameters.Add(key, value);

        public static RequestDefinition GetOrCreate(this RequestDefinitionCache cache, HttpMethod method, string path, IRateLimitGate rateLimitGate, int weight = 1, bool authenticated = false)
            => cache.GetOrCreate(method, string.Empty, path, rateLimitGate, weight, authenticated);

        public static RequestDefinition GetOrCreate(
            this RequestDefinitionCache cache,
            HttpMethod method,
            string path,
            IRateLimitGate rateLimitGate,
            int weight,
            bool authenticated,
            IRateLimitGuard? limitGuard = null,
            RequestBodyFormat? requestBodyFormat = null,
            HttpMethodParameterPosition? parameterPosition = null,
            ArrayParametersSerialization? arraySerialization = null,
            bool? preventCaching = null,
            bool? tryParseOnNonSuccess = null,
            bool? forcePathEndWithSlash = null,
            string? identifier = null)
            => cache.GetOrCreate(method, string.Empty, path, rateLimitGate, weight, authenticated, limitGuard, requestBodyFormat, parameterPosition, arraySerialization, preventCaching, tryParseOnNonSuccess, forcePathEndWithSlash, identifier);

        public static HttpResult<TTarget> As<TTarget>(this IHttpResult result, TTarget? data)
            => result.Success
                ? HttpResult.Ok(result, data!)
                : HttpResult.Fail<TTarget>(result);

        public static HttpResult AsDataless(this IHttpResult result)
            => result.Success
                ? HttpResult.Ok(result)
                : HttpResult.Fail(result);
    }
}
