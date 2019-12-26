using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CSRedis;

namespace EL.Common
{
    /// <summary>
    /// Redis扩展类
    /// </summary>
    public class RedisExt
    {
        private static CSRedisClient client = new CSRedisClient(new JsonConfigManager().GetValue<string>("RedisConnection"));

        /// <summary>
        /// Redis初始化
        /// </summary>
        public static void Init()
        {
            RedisHelper.Initialization(client);
        }

        #region String

        /// <summary>
        /// String写入
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expireSeconds">过期时间（秒）</param>
        /// <returns></returns>
        public static bool SetString(string key, object value, int expireSeconds)
        {
            return RedisHelper.Set(key, value, expireSeconds);
        }
        public static async Task<bool> SetStringAsync(string key, object value, int expireSeconds)
        {
            return await RedisHelper.SetAsync(key, value, expireSeconds);
        }

        /// <summary>
        /// String批量写入
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public static bool SetString(object[] keyValues)
        {
            return RedisHelper.MSet(keyValues);
        }
        public static async Task<bool> SetStringAsync(object[] keyValues)
        {
            return await RedisHelper.MSetAsync(keyValues);
        }

        /// <summary>
        /// String读取
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetString(string key)
        {
            return RedisHelper.Get(key);
        }
        public static async Task<string> GetStringAsync(string key)
        {
            return await RedisHelper.GetAsync(key);
        }
        public static T GetString<T>(string key)
        {
            return RedisHelper.Get<T>(key);
        }
        public static async Task<T> GetStringAsync<T>(string key)
        {
            return await RedisHelper.GetAsync<T>(key);
        }

        /// <summary>
        /// String批量读取
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keys"></param>
        /// <returns></returns>
        public static string[] GetString(string[] keys)
        {
            return RedisHelper.MGet(keys);
        }
        public static async Task<string[]> GetStringAsync(string[] keys)
        {
            return await RedisHelper.MGetAsync(keys);
        }
        public static T[] GetString<T>(string[] keys)
        {
            return RedisHelper.MGet<T>(keys);
        }
        public static async Task<T[]> GetStringAsync<T>(string[] keys)
        {
            return await RedisHelper.MGetAsync<T>(keys);
        }

        #endregion

        #region List

        /// <summary>
        /// 将一个或多个值 value 插入到列表 key 的表尾(最右边)
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static long SetListR<T>(string key, T[] value)
        {
            return RedisHelper.RPush(key, value);
        }
        public static async Task<long> SetListRAsync<T>(string key, T[] value)
        {
            return await RedisHelper.RPushAsync(key, value);
        }

        /// <summary>
        /// 将一个或多个值 value 插入到列表 key 的表尾(最左边)
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static long SetListL<T>(string key, T[] value)
        {
            return RedisHelper.LPush(key, value);
        }
        public static async Task<long> SetListLAsync<T>(string key, T[] value)
        {
            return await RedisHelper.LPushAsync(key, value);
        }

        /// <summary>
        /// 移除并返回列表 key 的头元素(最左边)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetListL(string key)
        {
            return RedisHelper.LPop(key);
        }
        public static async Task<string> GetListLAsync(string key)
        {
            return await RedisHelper.LPopAsync(key);
        }
        public static T GetListL<T>(string key)
        {
            return RedisHelper.LPop<T>(key);
        }
        public static async Task<T> GetListLAsync<T>(string key)
        {
            return await RedisHelper.LPopAsync<T>(key);
        }

        /// <summary>
        /// 移除并返回列表 key 的尾元素(最右边)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetListR(string key)
        {
            return RedisHelper.RPop(key);
        }
        public static async Task<string> GetListRAsync(string key)
        {
            return await RedisHelper.RPopAsync(key);
        }
        public static T GetListR<T>(string key)
        {
            return RedisHelper.RPop<T>(key);
        }
        public static async Task<T> GetListRAsync<T>(string key)
        {
            return await RedisHelper.RPopAsync<T>(key);
        }

        /// <summary>
        /// 将值 value 插入到列表 key 的表尾(最左边)
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static long ListPushL(string key, object value)
        {
            return RedisHelper.LPushX(key, value);
        }
        public static async Task<long> ListPushLAsync(string key, object value)
        {
            return await RedisHelper.LPushXAsync(key, value);
        }

        /// <summary>
        /// 将值 value 插入到列表 key 的表尾(最右边)
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static long ListPushR(string key, object value)
        {
            return RedisHelper.RPushX(key, value);
        }
        public static async Task<long> ListPushRAsync(string key, object value)
        {
            return await RedisHelper.RPushXAsync(key, value);
        }

        /// <summary>
        /// 根据下标获取元素
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static string GetListByIndex(string key, long index)
        {
            return RedisHelper.LIndex(key, index);
        }
        public static async Task<string> GetListByIndexAsync(string key, long index)
        {
            return await RedisHelper.LIndexAsync(key, index);
        }
        public static T GetListByIndex<T>(string key, long index)
        {
            return RedisHelper.LIndex<T>(key, index);
        }
        public static async Task<T> GetListByIndexAsync<T>(string key, long index)
        {
            return await RedisHelper.LIndexAsync<T>(key, index);
        }

        /// <summary>
        /// 获取列表长度
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static long GetListLen(string key)
        {
            return RedisHelper.LLen(key);
        }
        public static async Task<long> GetListLenAsync(string key)
        {
            return await RedisHelper.LLenAsync(key);
        }

        #endregion

        #region Hash

        /// <summary>
        /// 删除Hash表 key 中的一个或多个指定域，不存在的域将被忽略
        /// </summary>
        /// <param name="key"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public static long HashDelete(string key, string[] fields)
        {
            return RedisHelper.HDel(key, fields);
        }
        public static async Task<long> HashDeleteAsync(string key, string[] fields)
        {
            return await RedisHelper.HDelAsync(key, fields);
        }

        /// <summary>
        /// 查看Hash表 key 中，给定域 field 是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public static bool HashExists(string key, string fields)
        {
            return RedisHelper.HExists(key, fields);
        }
        public static async Task<bool> HashExistsAsync(string key, string fields)
        {
            return await RedisHelper.HExistsAsync(key, fields);
        }

        /// <summary>
        /// Hash获取
        /// </summary>
        /// <param name="key"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public static string HashGet(string key, string fields)
        {
            return RedisHelper.HGet(key, fields);
        }
        public static async Task<string> HashGetAsync(string key, string fields)
        {
            return await RedisHelper.HGetAsync(key, fields);
        }
        public static T HashGet<T>(string key, string fields)
        {
            return RedisHelper.HGet<T>(key, fields);
        }
        public static async Task<T> HashGetAsync<T>(string key, string fields)
        {
            return await RedisHelper.HGetAsync<T>(key, fields);
        }
        public static string[] HashGetRange(string key, string[] fields)
        {
            return RedisHelper.HMGet(key, fields);
        }
        public static async Task<string[]> HashGetRangeAsync(string key, string fields)
        {
            return await RedisHelper.HMGetAsync(key, fields);
        }
        public static T[] HashGetRange<T>(string key, string[] fields)
        {
            return RedisHelper.HMGet<T>(key, fields);
        }
        public static async Task<T[]> HashGetRangeAsync<T>(string key, string fields)
        {
            return await RedisHelper.HMGetAsync<T>(key, fields);
        }

        /// <summary>
        /// Hash写入
        /// </summary>
        /// <param name="key"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public static bool HashSet(string key, string field, object value)
        {
            return RedisHelper.HSet(key, field, value);
        }
        public static async Task<bool> HashSetAsync(string key, string field, object value)
        {
            return await RedisHelper.HSetAsync(key, field, value);
        }
        public static bool HashSet(string key, object[] keyValues)
        {
            return RedisHelper.HMSet(key, keyValues);
        }
        public static async Task<bool> HashSetAsync(string key, object[] keyValues)
        {
            return await RedisHelper.HMSetAsync(key, keyValues);
        }

        /// <summary>
        /// 获取Hash所有value的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string[] GetHashAllVals(string key)
        {
            return RedisHelper.HVals(key);
        }
        public static async Task<string[]> GetHashAllValsAsync(string key)
        {
            return await RedisHelper.HValsAsync(key);
        }
        public static T[] GetHashAllVals<T>(string key)
        {
            return RedisHelper.HVals<T>(key);
        }
        public static async Task<T[]> GetHashAllValsAsync<T>(string key)
        {
            return await RedisHelper.HValsAsync<T>(key);
        }

        /// <summary>
        /// 获取在Hash表中指定 key 的所有字段和值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="fields"></param>
        /// <returns></returns>
        public static Dictionary<string, T> HashGetAll<T>(string key)
        {
            return RedisHelper.HGetAll<T>(key);
        }
        public static async Task<Dictionary<string, T>> HashGetAllAsync<T>(string key)
        {
            return await RedisHelper.HGetAllAsync<T>(key);
        }

        /// <summary>
        /// 获取Hash所有Key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string[] HashKeys(string key)
        {
            return RedisHelper.HKeys(key);
        }
        public static async Task<string[]> HashKeysAsync(string key)
        {
            return await RedisHelper.HKeysAsync(key);
        }

        /// <summary>
        /// 获取Hash表中字段的数量
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static long HashLen(string key)
        {
            return RedisHelper.HLen(key);
        }
        public static async Task<long> HashLenAsync(string key)
        {
            return await RedisHelper.HLenAsync(key);
        }

        #endregion

        #region Set

        /// <summary>
        /// 向集合添加一个或多个成员
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="members"></param>
        /// <returns></returns>
        public static long SetAdd<T>(string key, T[] members)
        {
            return RedisHelper.SAdd<T>(key, members);
        }
        public static async Task<long> SetAddAsync<T>(string key, T[] members)
        {
            return await RedisHelper.SAddAsync<T>(key, members);
        }

        /// <summary>
        /// 获取集合的成员数
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static long SetCard(string key)
        {
            return RedisHelper.SCard(key);
        }
        public static async Task<long> SetCardAsync(string key)
        {
            return await RedisHelper.SCardAsync(key);
        }

        /// <summary>
        /// 返回给定所有集合的差集
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keys"></param>
        /// <returns></returns>
        public static string[] SetDiff(string[] keys)
        {
            return RedisHelper.SDiff(keys);
        }
        public static async Task<string[]> SetDiffAsync(string[] keys)
        {
            return await RedisHelper.SDiffAsync(keys);
        }
        public static T[] SetDiff<T>(string[] keys)
        {
            return RedisHelper.SDiff<T>(keys);
        }
        public static async Task<T[]> SetDiffAsync<T>(string[] keys)
        {
            return await RedisHelper.SDiffAsync<T>(keys);
        }

        /// <summary>
        /// 返回给定所有集合的交集
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="keys"></param>
        /// <returns></returns>
        public static string[] SetInter(string[] keys)
        {
            return RedisHelper.SInter(keys);
        }
        public static async Task<string[]> SetInterAsync(string[] keys)
        {
            return await RedisHelper.SInterAsync(keys);
        }
        public static T[] SetInter<T>(string[] keys)
        {
            return RedisHelper.SInter<T>(keys);
        }
        public static async Task<T[]> SetInterAsync<T>(string[] keys)
        {
            return await RedisHelper.SInterAsync<T>(keys);
        }

        /// <summary>
        /// 返回所有给定集合的并集
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        public static string[] SetUnion(string[] keys)
        {
            return RedisHelper.SUnion(keys);
        }
        public static async Task<string[]> SetUnionAsync(string[] keys)
        {
            return await RedisHelper.SUnionAsync(keys);
        }
        public static T[] SetUnion<T>(string[] keys)
        {
            return RedisHelper.SUnion<T>(keys);
        }
        public static async Task<T[]> SetUnionAsync<T>(string[] keys)
        {
            return await RedisHelper.SUnionAsync<T>(keys);
        }

        /// <summary>
        /// 返回集合中的所有成员
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string[] SetMembers(string key)
        {
            return RedisHelper.SMembers(key);
        }
        public static async Task<string[]> SetMembersAsync(string key)
        {
            return await RedisHelper.SMembersAsync(key);
        }
        public static T[] SetMembers<T>(string key)
        {
            return RedisHelper.SMembers<T>(key);
        }
        public static async Task<T[]> SetMembersAsync<T>(string key)
        {
            return await RedisHelper.SMembersAsync<T>(key);
        }

        /// <summary>
        /// 判断 member 元素是否是集合 key 的成员
        /// </summary>
        /// <param name="key"></param>
        /// <param name="member"></param>
        /// <returns></returns>
        public static bool SetIsMember(string key, object member)
        {
            return RedisHelper.SIsMember(key, member);
        }
        public static async Task<bool> SetIsMemberAsync(string key, object member)
        {
            return await RedisHelper.SIsMemberAsync(key, member);
        }

        /// <summary>
        /// 移除并返回集合中的一个随机元素
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string SetPop(string key)
        {
            return RedisHelper.SPop(key);
        }
        public static async Task<string> SetPopAsync(string key)
        {
            return await RedisHelper.SPopAsync(key);
        }
        public static T SetPop<T>(string key)
        {
            return RedisHelper.SPop<T>(key);
        }
        public static async Task<T> SetPopAsync<T>(string key)
        {
            return await RedisHelper.SPopAsync<T>(key);
        }

        /// <summary>
        /// 移除集合中一个或多个成员
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <param name="members"></param>
        /// <returns></returns>
        public static long SetRem<T>(string key, T[] members)
        {
            return RedisHelper.SRem(key, members);
        }
        public static async Task<long> SetRemAsync<T>(string key, T[] members)
        {
            return await RedisHelper.SRemAsync(key, members);
        }

        #endregion

        #region Sorted Set
        /// <summary>
        /// 向有序集合添加一个或多个成员，或者更新已存在成员的分数
        /// </summary>
        /// <param name="key">不含prefix前辍</param>
        /// <param name="scoreMembers">一个或多个成员分数</param>
        /// <returns></returns>
        public static long ZAdd(string key, params (decimal, object)[] scoreMembers)
        {
            return RedisHelper.ZAdd(key, scoreMembers);
        }
        public static async Task<long> ZAddAsync(string key, params (decimal, object)[] scoreMembers)
        {
            return await RedisHelper.ZAddAsync(key, scoreMembers);
        }

        /// <summary>
        /// 获取有序集合的成员数量
        /// </summary>
        /// <param name="key">不含prefix前辍</param>
        /// <returns></returns>
        public static long ZCard(string key)
        {
            return RedisHelper.ZCard(key);
        }
        public static async Task<long> ZCardAsync(string key)
        {
            return await RedisHelper.ZCardAsync(key);
        }

        /// <summary>
        /// 计算在有序集合中指定区间分数的成员数量
        /// </summary>
        /// <param name="key">不含prefix前辍</param>
        /// <param name="min">分数最小值 decimal.MinValue 1</param>
        /// <param name="max">分数最大值 decimal.MaxValue 10</param>
        /// <returns></returns>
        public static long ZCount(string key, decimal min, decimal max)
        {
            return RedisHelper.ZCount(key, min, max);
        }
        public static async Task<long> ZCountAsync(string key, decimal min, decimal max)
        {
            return await RedisHelper.ZCountAsync(key, min, max);
        }
        public static long ZCount(string key, string min, string max)
        {
            return RedisHelper.ZCount(key, min, max);
        }
        public static async Task<long> ZCountAsync(string key, string min, string max)
        {
            return await RedisHelper.ZCountAsync(key, min, max);
        }

        /// <summary>
        /// 有序集合中对指定成员的分数加上增量 increment
        /// </summary>
        /// <param name="key">不含prefix前辍</param>
        /// <param name="member">成员</param>
        /// <param name="increment">增量值(默认=1)</param>
        /// <returns></returns>
        public static decimal ZIncrBy(string key, string member, decimal increment = 1)
        {
            return RedisHelper.ZIncrBy(key, member, increment);
        }
        public static async Task<decimal> ZIncrByAsync(string key, string member, decimal increment = 1)
        {
            return await RedisHelper.ZIncrByAsync(key, member, increment);
        }

        /// <summary>
        /// 计算给定的一个或多个有序集的交集，将结果集存储在新的有序集合 destination 中
        /// </summary>
        /// <param name="destination">新的有序集合，不含prefix前辍</param>
        /// <param name="weights">使用 WEIGHTS 选项，你可以为 每个 给定有序集 分别 指定一个乘法因子。如果没有指定 WEIGHTS 选项，乘法因子默认设置为 1 。</param>
        /// <param name="aggregate">Sum | Min | Max</param>
        /// <param name="keys">一个或多个有序集合，不含prefix前辍</param>
        /// <returns></returns>
        public static long ZInterStore(string destination, decimal[] weights, RedisAggregate aggregate, params string[] keys)
        {
            return RedisHelper.ZInterStore(destination, weights, aggregate, keys);
        }
        public static async Task<long> ZInterStoreAsync(string destination, decimal[] weights, RedisAggregate aggregate, params string[] keys)
        {
            return await RedisHelper.ZInterStoreAsync(destination, weights, aggregate, keys);
        }

        /// <summary>
        /// 通过索引区间返回有序集合成指定区间内的成员
        /// </summary>
        /// <param name="key">不含prefix前辍</param>
        /// <param name="start">开始位置，0表示第一个元素，-1表示最后一个元素</param>
        /// <param name="stop">结束位置，0表示第一个元素，-1表示最后一个元素</param>
        /// <returns></returns>
        public static string[] ZRange(string key, long start, long stop)
        {
            return RedisHelper.ZRange(key, start, stop);
        }
        public static async Task<string[]> ZRangeAsync(string key, long start, long stop)
        {
            return await RedisHelper.ZRangeAsync(key, start, stop);
        }
        public static T[] ZRange<T>(string key, long start, long stop)
        {
            return RedisHelper.ZRange<T>(key, start, stop);
        }
        public static async Task<T[]> ZRangeAsync<T>(string key, long start, long stop)
        {
            return await RedisHelper.ZRangeAsync<T>(key, start, stop);
        }

        /// <summary>
        /// 通过索引区间返回有序集合成指定区间内的成员和分数
        /// </summary>
        /// <param name="key">不含prefix前辍</param>
        /// <param name="start">开始位置，0表示第一个元素，-1表示最后一个元素</param>
        /// <param name="stop">结束位置，0表示第一个元素，-1表示最后一个元素</param>
        /// <returns></returns>
        public static (string member, decimal score)[] ZRangeWithScores(string key, long start, long stop)
        {
            return RedisHelper.ZRangeWithScores(key, start, stop);
        }
        public static async Task<(string member, decimal score)[]> ZRangeWithScoresAsync(string key, long start, long stop)
        {
            return await RedisHelper.ZRangeWithScoresAsync(key, start, stop);
        }
        public static (T member, decimal score)[] ZRangeWithScores<T>(string key, long start, long stop)
        {
            return RedisHelper.ZRangeWithScores<T>(key, start, stop);
        }
        public static async Task<(T member, decimal score)[]> ZRangeWithScoresAsync<T>(string key, long start, long stop)
        {
            return await RedisHelper.ZRangeWithScoresAsync<T>(key, start, stop);
        }

        /// <summary>
        /// 通过分数返回有序集合指定区间内的成员
        /// </summary>
        /// <param name="key">不含prefix前辍</param>
        /// <param name="min">分数最小值 decimal.MinValue 1</param>
        /// <param name="max">分数最大值 decimal.MaxValue 10</param>
        /// <param name="limit">返回多少成员</param>
        /// <param name="offset">返回条件偏移位置</param>
        /// <returns></returns>
        public static string[] ZRangeByScore(string key, decimal min, decimal max, long? limit = null, long offset = 0)
        {
            return RedisHelper.ZRangeByScore(key, min, max, limit, offset);
        }
        public static async Task<string[]> ZRangeByScoreAsync(string key, decimal min, decimal max, long? limit = null, long offset = 0)
        {
            return await RedisHelper.ZRangeByScoreAsync(key, min, max, limit, offset);
        }
        public static T[] ZRangeByScore<T>(string key, decimal min, decimal max, long? limit = null, long offset = 0)
        {
            return RedisHelper.ZRangeByScore<T>(key, min, max, limit, offset);
        }
        public static async Task<T[]> ZRangeByScoreAsync<T>(string key, decimal min, decimal max, long? limit = null, long offset = 0)
        {
            return await RedisHelper.ZRangeByScoreAsync<T>(key, min, max, limit, offset);
        }

        /// <summary>
        /// 通过分数返回有序集合指定区间内的成员
        /// </summary>
        /// <param name="key">不含prefix前辍</param>
        /// <param name="min">分数最小值 -inf (1 1</param>
        /// <param name="max">分数最大值 +inf (10 10</param>
        /// <param name="limit">返回多少成员</param>
        /// <param name="offset">返回条件偏移位置</param>
        /// <returns></returns>
        public static string[] ZRangeByScore(string key, string min, string max, long? limit = null, long offset = 0)
        {
            return RedisHelper.ZRangeByScore(key, min, max, limit, offset);
        }
        public static async Task<string[]> ZRangeByScoreAsync(string key, string min, string max, long? limit = null, long offset = 0)
        {
            return await RedisHelper.ZRangeByScoreAsync(key, min, max, limit, offset);
        }
        public static T[] ZRangeByScore<T>(string key, string min, string max, long? limit = null, long offset = 0)
        {
            return RedisHelper.ZRangeByScore<T>(key, min, max, limit, offset);
        }
        public static async Task<T[]> ZRangeByScoreAsync<T>(string key, string min, string max, long? limit = null, long offset = 0)
        {
            return await RedisHelper.ZRangeByScoreAsync<T>(key, min, max, limit, offset);
        }

        /// <summary>
        /// 通过分数返回有序集合指定区间内的成员和分数
        /// </summary>
        /// <param name="key">不含prefix前辍</param>
        /// <param name="min">分数最小值 decimal.MinValue 1</param>
        /// <param name="max">分数最大值 decimal.MaxValue 10</param>
        /// <param name="limit">返回多少成员</param>
        /// <param name="offset">返回条件偏移位置</param>
        /// <returns></returns>
        public static (string member, decimal score)[] ZRangeByScoreWithScores(string key, decimal min, decimal max, long? limit = null, long offset = 0)
        {
            return RedisHelper.ZRangeByScoreWithScores(key, min, max, limit, offset);
        }
        public static async Task<(string member, decimal score)[]> ZRangeByScoreWithScoresAsync(string key, decimal min, decimal max, long? limit = null, long offset = 0)
        {
            return await RedisHelper.ZRangeByScoreWithScoresAsync(key, min, max, limit, offset);
        }
        public static (T member, decimal score)[] ZRangeByScoreWithScores<T>(string key, decimal min, decimal max, long? limit = null, long offset = 0)
        {
            return RedisHelper.ZRangeByScoreWithScores<T>(key, min, max, limit, offset);
        }
        public static async Task<(T member, decimal score)[]> ZRangeByScoreWithScoresAsync<T>(string key, decimal min, decimal max, long? limit = null, long offset = 0)
        {
            return await RedisHelper.ZRangeByScoreWithScoresAsync<T>(key, min, max, limit, offset);
        }

        /// <summary>
        /// 通过分数返回有序集合指定区间内的成员和分数
        /// </summary>
        /// <param name="key">不含prefix前辍</param>
        /// <param name="min">分数最小值 -inf (1 1</param>
        /// <param name="max">分数最大值 +inf (10 10</param>
        /// <param name="limit">返回多少成员</param>
        /// <param name="offset">返回条件偏移位置</param>
        /// <returns></returns>
        public static (string member, decimal score)[] ZRangeByScoreWithScores(string key, string min, string max, long? limit = null, long offset = 0)
        {
            return RedisHelper.ZRangeByScoreWithScores(key, min, max, limit, offset);
        }
        public static async Task<(string member, decimal score)[]> ZRangeByScoreWithScoresAsync(string key, string min, string max, long? limit = null, long offset = 0)
        {
            return await RedisHelper.ZRangeByScoreWithScoresAsync(key, min, max, limit, offset);
        }
        public static (T member, decimal score)[] ZRangeByScoreWithScores<T>(string key, string min, string max, long? limit = null, long offset = 0)
        {
            return RedisHelper.ZRangeByScoreWithScores<T>(key, min, max, limit, offset);
        }
        public static async Task<(T member, decimal score)[]> ZRangeByScoreWithScoresAsync<T>(string key, string min, string max, long? limit = null, long offset = 0)
        {
            return await RedisHelper.ZRangeByScoreWithScoresAsync<T>(key, min, max, limit, offset);
        }

        /// <summary>
        /// 返回有序集合中指定成员的索引
        /// </summary>
        /// <param name="key">不含prefix前辍</param>
        /// <param name="member">成员</param>
        /// <returns></returns>
        public static long? ZRank(string key, object member)
        {
            return RedisHelper.ZRank(key, member);
        }
        public static async Task<long?> ZRankAsync(string key, object member)
        {
            return await RedisHelper.ZRankAsync(key, member);
        }

        /// <summary>
        /// 移除有序集合中的一个或多个成员
        /// </summary>
        /// <param name="key">不含prefix前辍</param>
        /// <param name="member">一个或多个成员</param>
        /// <returns></returns>
        public static long ZRem<T>(string key, params T[] member)
        {
            return RedisHelper.ZRem(key, member);
        }
        public static async Task<long> ZRemAsync<T>(string key, params T[] member)
        {
            return await RedisHelper.ZRemAsync(key, member);
        }

        /// <summary>
        /// 移除有序集合中给定的排名区间的所有成员
        /// </summary>
        /// <param name="key">不含prefix前辍</param>
        /// <param name="start">开始位置，0表示第一个元素，-1表示最后一个元素</param>
        /// <param name="stop">结束位置，0表示第一个元素，-1表示最后一个元素</param>
        /// <returns></returns>
        public static long ZRemRangeByRank(string key, long start, long stop)
        {
            return RedisHelper.ZRemRangeByRank(key, start, stop);
        }
        public static async Task<long> ZRemRangeByRankAsync(string key, long start, long stop)
        {
            return await RedisHelper.ZRemRangeByRankAsync(key, start, stop);
        }

        /// <summary>
        /// 移除有序集合中给定的分数区间的所有成员
        /// </summary>
        /// <param name="key">不含prefix前辍</param>
        /// <param name="min">分数最小值 decimal.MinValue 1</param>
        /// <param name="max">分数最大值 decimal.MaxValue 10</param>
        /// <returns></returns>
        public static long ZRemRangeByScore(string key, decimal min, decimal max)
        {
            return RedisHelper.ZRemRangeByScore(key, min, max);
        }
        public static async Task<long> ZRemRangeByScoreAsync(string key, decimal min, decimal max)
        {
            return await RedisHelper.ZRemRangeByScoreAsync(key, min, max);
        }
        public static long ZRemRangeByScore(string key, string min, string max)
        {
            return RedisHelper.ZRemRangeByScore(key, min, max);
        }
        public static async Task<long> ZRemRangeByScoreAsync(string key, string min, string max)
        {
            return await RedisHelper.ZRemRangeByScoreAsync(key, min, max);
        }

        /// <summary>
        /// 返回有序集中指定区间内的成员，通过索引，分数从高到底
        /// </summary>
        /// <param name="key">不含prefix前辍</param>
        /// <param name="start">开始位置，0表示第一个元素，-1表示最后一个元素</param>
        /// <param name="stop">结束位置，0表示第一个元素，-1表示最后一个元素</param>
        /// <returns></returns>
        public static string[] ZRevRange(string key, long start, long stop)
        {
            return RedisHelper.ZRevRange(key, start, stop);
        }
        public static async Task<string[]> ZRevRangeAsync(string key, long start, long stop)
        {
            return await RedisHelper.ZRevRangeAsync(key, start, stop);
        }
        public static T[] ZRevRange<T>(string key, long start, long stop)
        {
            return RedisHelper.ZRevRange<T>(key, start, stop);
        }
        public static async Task<T[]> ZRevRangeAsync<T>(string key, long start, long stop)
        {
            return await RedisHelper.ZRevRangeAsync<T>(key, start, stop);
        }

        /// <summary>
        /// 返回有序集中指定区间内的成员和分数，通过索引，分数从高到底
        /// </summary>
        /// <param name="key">不含prefix前辍</param>
        /// <param name="start">开始位置，0表示第一个元素，-1表示最后一个元素</param>
        /// <param name="stop">结束位置，0表示第一个元素，-1表示最后一个元素</param>
        /// <returns></returns>
        public static (string member, decimal score)[] ZRevRangeWithScores(string key, long start, long stop)
        {
            return RedisHelper.ZRevRangeWithScores(key, start, stop);
        }
        public static async Task<(string member, decimal score)[]> ZRevRangeWithScoresAsync(string key, long start, long stop)
        {
            return await RedisHelper.ZRevRangeWithScoresAsync(key, start, stop);
        }
        public static (T member, decimal score)[] ZRevRangeWithScores<T>(string key, long start, long stop)
        {
            return RedisHelper.ZRevRangeWithScores<T>(key, start, stop);
        }
        public static async Task<(T member, decimal score)[]> ZRevRangeWithScoresAsync<T>(string key, long start, long stop)
        {
            return await RedisHelper.ZRevRangeWithScoresAsync<T>(key, start, stop);
        }

        /// <summary>
        /// 返回有序集中指定分数区间内的成员，分数从高到低排序
        /// </summary>
        /// <param name="key">不含prefix前辍</param>
        /// <param name="max">分数最大值 decimal.MaxValue 10</param>
        /// <param name="min">分数最小值 decimal.MinValue 1</param>
        /// <param name="limit">返回多少成员</param>
        /// <param name="offset">返回条件偏移位置</param>
        /// <returns></returns>
        public static string[] ZRevRangeByScore(string key, decimal max, decimal min, long? limit = null, long? offset = 0)
        {
            return RedisHelper.ZRevRangeByScore(key, max, min, limit, offset);
        }
        public static async Task<string[]> ZRevRangeByScoreAsync(string key, decimal max, decimal min, long? limit = null, long? offset = 0)
        {
            return await RedisHelper.ZRevRangeByScoreAsync(key, max, min, limit, offset);
        }
        public static T[] ZRevRangeByScore<T>(string key, decimal max, decimal min, long? limit = null, long offset = 0)
        {
            return RedisHelper.ZRevRangeByScore<T>(key, max, min, limit, offset);
        }
        public static async Task<T[]> ZRevRangeByScoreAsync<T>(string key, decimal max, decimal min, long? limit = null, long offset = 0)
        {
            return await RedisHelper.ZRevRangeByScoreAsync<T>(key, max, min, limit, offset);
        }

        /// <summary>
        /// 返回有序集中指定分数区间内的成员，分数从高到低排序
        /// </summary>
        /// <param name="key">不含prefix前辍</param>
        /// <param name="max">分数最大值 +inf (10 10</param>
        /// <param name="min">分数最小值 -inf (1 1</param>
        /// <param name="limit">返回多少成员</param>
        /// <param name="offset">返回条件偏移位置</param>
        /// <returns></returns>
        public static string[] ZRevRangeByScore(string key, string max, string min, long? limit = null, long? offset = 0)
        {
            return RedisHelper.ZRevRangeByScore(key, max, min, limit, offset);
        }
        public static async Task<string[]> ZRevRangeByScoreAsync(string key, string max, string min, long? limit = null, long? offset = 0)
        {
            return await RedisHelper.ZRevRangeByScoreAsync(key, max, min, limit, offset);
        }
        public static T[] ZRevRangeByScore<T>(string key, string max, string min, long? limit = null, long offset = 0)
        {
            return RedisHelper.ZRevRangeByScore<T>(key, max, min, limit, offset);
        }
        public static async Task<T[]> ZRevRangeByScoreAsync<T>(string key, string max, string min, long? limit = null, long offset = 0)
        {
            return await RedisHelper.ZRevRangeByScoreAsync<T>(key, max, min, limit, offset);
        }

        /// <summary>
        /// 返回有序集中指定分数区间内的成员和分数，分数从高到低排序
        /// </summary>
        /// <param name="key">不含prefix前辍</param>
        /// <param name="max">分数最大值 decimal.MaxValue 10</param>
        /// <param name="min">分数最小值 decimal.MinValue 1</param>
        /// <param name="limit">返回多少成员</param>
        /// <param name="offset">返回条件偏移位置</param>
        /// <returns></returns>
        public static (string member, decimal score)[] ZRevRangeByScoreWithScores(string key, decimal max, decimal min, long? limit = null, long offset = 0)
        {
            return RedisHelper.ZRevRangeByScoreWithScores(key, max, min, limit, offset);
        }
        public static async Task<(string member, decimal score)[]> ZRevRangeByScoreWithScoresAsync(string key, decimal max, decimal min, long? limit = null, long offset = 0)
        {
            return await RedisHelper.ZRevRangeByScoreWithScoresAsync(key, max, min, limit, offset);
        }
        public static (T member, decimal score)[] ZRevRangeByScoreWithScores<T>(string key, decimal max, decimal min, long? limit = null, long offset = 0)
        {
            return RedisHelper.ZRevRangeByScoreWithScores<T>(key, max, min, limit, offset);
        }
        public static async Task<(T member, decimal score)[]> ZRevRangeByScoreWithScoresAsync<T>(string key, decimal max, decimal min, long? limit = null, long offset = 0)
        {
            return await RedisHelper.ZRevRangeByScoreWithScoresAsync<T>(key, max, min, limit, offset);
        }

        /// <summary>
        /// 返回有序集中指定分数区间内的成员和分数，分数从高到低排序
        /// </summary>
        /// <param name="key">不含prefix前辍</param>
        /// <param name="max">分数最大值 +inf (10 10</param>
        /// <param name="min">分数最小值 -inf (1 1</param>
        /// <param name="limit">返回多少成员</param>
        /// <param name="offset">返回条件偏移位置</param>
        /// <returns></returns>
        public static (string member, decimal score)[] ZRevRangeByScoreWithScores(string key, string max, string min, long? limit = null, long offset = 0)
        {
            return RedisHelper.ZRevRangeByScoreWithScores(key, max, min, limit, offset);
        }
        public static async Task<(string member, decimal score)[]> ZRevRangeByScoreWithScoresAsync(string key, string max, string min, long? limit = null, long offset = 0)
        {
            return await RedisHelper.ZRevRangeByScoreWithScoresAsync(key, max, min, limit, offset);
        }
        public static (T member, decimal score)[] ZRevRangeByScoreWithScores<T>(string key, string max, string min, long? limit = null, long offset = 0)
        {
            return RedisHelper.ZRevRangeByScoreWithScores<T>(key, max, min, limit, offset);
        }
        public static async Task<(T member, decimal score)[]> ZRevRangeByScoreWithScoresAsync<T>(string key, string max, string min, long? limit = null, long offset = 0)
        {
            return await RedisHelper.ZRevRangeByScoreWithScoresAsync<T>(key, max, min, limit, offset);
        }

        /// <summary>
        /// 返回有序集合中指定成员的排名，有序集成员按分数值递减(从大到小)排序
        /// </summary>
        /// <param name="key">不含prefix前辍</param>
        /// <param name="member">成员</param>
        /// <returns></returns>
        public static long? ZRevRank(string key, object member)
        {
            return RedisHelper.ZRevRank(key, member);
        }
        public static async Task<long?> ZRevRankAsync(string key, object member)
        {
            return await RedisHelper.ZRevRankAsync(key, member);
        }

        /// <summary>
        /// 返回有序集中，成员的分数值
        /// </summary>
        /// <param name="key">不含prefix前辍</param>
        /// <param name="member">成员</param>
        /// <returns></returns>
        public static decimal? ZScore(string key, object member)
        {
            return RedisHelper.ZScore(key, member);
        }
        public static async Task<decimal?> ZScoreAsync(string key, object member)
        {
            return await RedisHelper.ZScoreAsync(key, member);
        }

        /// <summary>
        /// 计算给定的一个或多个有序集的并集，将结果集存储在新的有序集合 destination 中
        /// </summary>
        /// <param name="destination">新的有序集合，不含prefix前辍</param>
        /// <param name="weights">使用 WEIGHTS 选项，你可以为 每个 给定有序集 分别 指定一个乘法因子。如果没有指定 WEIGHTS 选项，乘法因子默认设置为 1 。</param>
        /// <param name="aggregate">Sum | Min | Max</param>
        /// <param name="keys">一个或多个有序集合，不含prefix前辍</param>
        /// <returns></returns>
        public static long ZUnionStore(string destination, decimal[] weights, RedisAggregate aggregate, params string[] keys)
        {
            return RedisHelper.ZUnionStore(destination, weights, aggregate, keys);
        }
        public static async Task<long> ZUnionStoreAsync(string destination, decimal[] weights, RedisAggregate aggregate, params string[] keys)
        {
            return await RedisHelper.ZUnionStoreAsync(destination, weights, aggregate, keys);
        }

        /// <summary>
        /// 迭代有序集合中的元素
        /// </summary>
        /// <param name="key">不含prefix前辍</param>
        /// <param name="cursor">位置</param>
        /// <param name="pattern">模式</param>
        /// <param name="count">数量</param>
        /// <returns></returns>
        public static RedisScan<(string member, decimal score)> ZScan(string key, long cursor, string pattern = null, long? count = null)
        {
            return RedisHelper.ZScan(key, cursor, pattern, count);
        }
        public static async Task<RedisScan<(string member, decimal score)>> ZScanAsync(string key, long cursor, string pattern = null, long? count = null)
        {
            return await RedisHelper.ZScanAsync(key, cursor, pattern, count);
        }
        public static RedisScan<(T member, decimal score)> ZScan<T>(string key, long cursor, string pattern = null, long? count = null)
        {
            return RedisHelper.ZScan<T>(key, cursor, pattern, count);
        }
        public static async Task<RedisScan<(T member, decimal score)>> ZScanAsync<T>(string key, long cursor, string pattern = null, long? count = null)
        {
            return await RedisHelper.ZScanAsync<T>(key, cursor, pattern, count);
        }

        /// <summary>
        /// 当有序集合的所有成员都具有相同的分值时，有序集合的元素会根据成员的字典序来进行排序，这个命令可以返回给定的有序集合键 key 中，值介于 min 和 max 之间的成员。
        /// </summary>
        /// <param name="key">不含prefix前辍</param>
        /// <param name="min">'(' 表示包含在范围，'[' 表示不包含在范围，'+' 正无穷大，'-' 负无限。 ZRANGEBYLEX zset - + ，命令将返回有序集合中的所有元素</param>
        /// <param name="max">'(' 表示包含在范围，'[' 表示不包含在范围，'+' 正无穷大，'-' 负无限。 ZRANGEBYLEX zset - + ，命令将返回有序集合中的所有元素</param>
        /// <param name="limit">返回多少成员</param>
        /// <param name="offset">返回条件偏移位置</param>
        /// <returns></returns>
        public static string[] ZRangeByLex(string key, string min, string max, long? limit = null, long offset = 0)
        {
            return RedisHelper.ZRangeByLex(key, min, max, limit, offset);
        }
        public static async Task<string[]> ZRangeByLexAsync(string key, string min, string max, long? limit = null, long offset = 0)
        {
            return await RedisHelper.ZRangeByLexAsync(key, min, max, limit, offset);
        }
        public static T[] ZRangeByLex<T>(string key, string min, string max, long? limit = null, long offset = 0)
        {
            return RedisHelper.ZRangeByLex<T>(key, min, max, limit, offset);
        }
        public static async Task<T[]> ZRangeByLexAsync<T>(string key, string min, string max, long? limit = null, long offset = 0)
        {
            return await RedisHelper.ZRangeByLexAsync<T>(key, min, max, limit, offset);
        }

        /// <summary>
        /// 当有序集合的所有成员都具有相同的分值时，有序集合的元素会根据成员的字典序来进行排序，这个命令可以返回给定的有序集合键 key 中，值介于 min 和 max 之间的成员。
        /// </summary>
        /// <param name="key">不含prefix前辍</param>
        /// <param name="min">'(' 表示包含在范围，'[' 表示不包含在范围，'+' 正无穷大，'-' 负无限。 ZRANGEBYLEX zset - + ，命令将返回有序集合中的所有元素</param>
        /// <param name="max">'(' 表示包含在范围，'[' 表示不包含在范围，'+' 正无穷大，'-' 负无限。 ZRANGEBYLEX zset - + ，命令将返回有序集合中的所有元素</param>
        /// <returns></returns>
        public static long ZRemRangeByLex(string key, string min, string max)
        {
            return RedisHelper.ZRemRangeByLex(key, min, max);
        }
        public static async Task<long> ZRemRangeByLexAsync(string key, string min, string max)
        {
            return await RedisHelper.ZRemRangeByLexAsync(key, min, max);
        }

        /// <summary>
        /// 当有序集合的所有成员都具有相同的分值时，有序集合的元素会根据成员的字典序来进行排序，这个命令可以返回给定的有序集合键 key 中，值介于 min 和 max 之间的成员。
        /// </summary>
        /// <param name="key">不含prefix前辍</param>
        /// <param name="min">'(' 表示包含在范围，'[' 表示不包含在范围，'+' 正无穷大，'-' 负无限。 ZRANGEBYLEX zset - + ，命令将返回有序集合中的所有元素</param>
        /// <param name="max">'(' 表示包含在范围，'[' 表示不包含在范围，'+' 正无穷大，'-' 负无限。 ZRANGEBYLEX zset - + ，命令将返回有序集合中的所有元素</param>
        /// <returns></returns>
        public static long ZLexCount(string key, string min, string max)
        {
            return RedisHelper.ZLexCount(key, min, max);
        }
        public static async Task<long> ZLexCountAsync(string key, string min, string max)
        {
            return await RedisHelper.ZLexCountAsync(key, min, max);
        }

        #endregion

        #region Key操作

        /// <summary>
        /// Key重命名
        /// </summary>
        /// <param name="key"></param>
        /// <param name="newKey"></param>
        /// <returns></returns>
        public static bool Rename(string key, string newKey)
        {
            return RedisHelper.Rename(key, newKey);
        }
        public static async Task<bool> RenameAsync(string key, string newKey)
        {
            return await RedisHelper.RenameAsync(key, newKey);
        }

        /// <summary>
        /// 给 Key 设置过期时间
        /// </summary>
        /// <param name="key"></param>
        /// <param name="seconds">过期时间（秒）</param>
        /// <returns></returns>
        public static bool Expire(string key, int seconds)
        {
            return RedisHelper.Expire(key, seconds);
        }
        public static async Task<bool> ExpireAsync(string key, int seconds)
        {
            return await RedisHelper.ExpireAsync(key, seconds);
        }

        /// <summary>
        /// 判断 Key 是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool Exists(string key)
        {
            return RedisHelper.Exists(key);
        }
        public static async Task<bool> ExistsAsync(string key)
        {
            return await RedisHelper.ExistsAsync(key);
        }

        /// <summary>
        /// 批量判断 Key 是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static long ExistsRange(string[] key)
        {
            return RedisHelper.Exists(key);
        }
        public static async Task<long> ExistsRangeAsync(string[] key)
        {
            return await RedisHelper.ExistsAsync(key);
        }

        /// <summary>
        /// 删除 Key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static long Delete(string key)
        {
            return RedisHelper.Del(key);
        }
        public static async Task<long> DeleteAsync(string key)
        {
            return await RedisHelper.DelAsync(key);
        }

        /// <summary>
        /// 删除 Key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static long DeleteRange(string[] key)
        {
            return RedisHelper.Del(key);
        }
        public static async Task<long> DeleteRangeAsync(string[] key)
        {
            return await RedisHelper.DelAsync(key);
        }

        /// <summary>
        /// 移除Key的过期时间，将Key设置为永久保存
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool Persist(string key)
        {
            return RedisHelper.Persist(key);
        }
        public static async Task<bool> PersistAsync(string key)
        {
            return await RedisHelper.PersistAsync(key);
        }

        /// <summary>
        /// 以秒为单位，返回给定 key 的剩余生存时间
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static long Ttl(string key)
        {
            return RedisHelper.Ttl(key);
        }
        public static async Task<long> TtlAsync(string key)
        {
            return await RedisHelper.TtlAsync(key);
        }

        #endregion
    }
}
