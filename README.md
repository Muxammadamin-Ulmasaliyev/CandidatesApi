# ✅ Suggested Improvements

1. **Caching Layer**
   - Add caching (sliding expiration 5-10 minutes) to retrieving or checking candidate with email.
   - Could use `IMemoryCache` or a distributed cache like Redis.

2. **Pagination and Filtering**
   - Add support for pagination and search filters if a list endpoint is introduced later.

3. **Logging**
   - Introduce Serilog or built-in ILogger for tracking errors, API calls, and performance metrics.

---

- Total time spent : ~ 6 hours
