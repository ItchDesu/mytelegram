// ReSharper disable All

namespace MyTelegram.Schema.Stats;

///<summary>
/// Channel statistics
/// See <a href="https://corefork.telegram.org/constructor/stats.BroadcastStats" />
///</summary>
[JsonDerivedType(typeof(TBroadcastStats), nameof(TBroadcastStats))]
public interface IBroadcastStats : IObject
{
    ///<summary>
    /// Period in consideration
    /// See <a href="https://corefork.telegram.org/type/StatsDateRangeDays" />
    ///</summary>
    MyTelegram.Schema.IStatsDateRangeDays Period { get; set; }

    ///<summary>
    /// Follower count change for period in consideration
    /// See <a href="https://corefork.telegram.org/type/StatsAbsValueAndPrev" />
    ///</summary>
    MyTelegram.Schema.IStatsAbsValueAndPrev Followers { get; set; }

    ///<summary>
    /// <code>total_viewcount/postcount</code>, for posts posted during the period in consideration. <br>Note that in this case, <code>current</code> refers to the <code>period</code> in consideration (<code>min_date</code> till <code>max_date</code>), and <code>prev</code> refers to the previous period (<code>(min_date - (max_date - min_date))</code> till <code>min_date</code>).
    /// See <a href="https://corefork.telegram.org/type/StatsAbsValueAndPrev" />
    ///</summary>
    MyTelegram.Schema.IStatsAbsValueAndPrev ViewsPerPost { get; set; }

    ///<summary>
    /// <code>total_sharecount/postcount</code>, for posts posted during the period in consideration. <br>Note that in this case, <code>current</code> refers to the <code>period</code> in consideration (<code>min_date</code> till <code>max_date</code>), and <code>prev</code> refers to the previous period (<code>(min_date - (max_date - min_date))</code> till <code>min_date</code>)
    /// See <a href="https://corefork.telegram.org/type/StatsAbsValueAndPrev" />
    ///</summary>
    MyTelegram.Schema.IStatsAbsValueAndPrev SharesPerPost { get; set; }

    ///<summary>
    /// <code>total_reactions/postcount</code>, for posts posted during the period in consideration. <br>Note that in this case, <code>current</code> refers to the <code>period</code> in consideration (<code>min_date</code> till <code>max_date</code>), and <code>prev</code> refers to the previous period (<code>(min_date - (max_date - min_date))</code> till <code>min_date</code>)
    /// See <a href="https://corefork.telegram.org/type/StatsAbsValueAndPrev" />
    ///</summary>
    MyTelegram.Schema.IStatsAbsValueAndPrev ReactionsPerPost { get; set; }

    ///<summary>
    /// <code>total_views/storycount</code>, for posts posted during the period in consideration. <br>Note that in this case, <code>current</code> refers to the <code>period</code> in consideration (<code>min_date</code> till <code>max_date</code>), and <code>prev</code> refers to the previous period (<code>(min_date - (max_date - min_date))</code> till <code>min_date</code>)
    /// See <a href="https://corefork.telegram.org/type/StatsAbsValueAndPrev" />
    ///</summary>
    MyTelegram.Schema.IStatsAbsValueAndPrev ViewsPerStory { get; set; }

    ///<summary>
    /// <code>total_shares/storycount</code>, for posts posted during the period in consideration. <br>Note that in this case, <code>current</code> refers to the <code>period</code> in consideration (<code>min_date</code> till <code>max_date</code>), and <code>prev</code> refers to the previous period (<code>(min_date - (max_date - min_date))</code> till <code>min_date</code>)
    /// See <a href="https://corefork.telegram.org/type/StatsAbsValueAndPrev" />
    ///</summary>
    MyTelegram.Schema.IStatsAbsValueAndPrev SharesPerStory { get; set; }

    ///<summary>
    /// <code>total_reactions/storycount</code>, for posts posted during the period in consideration. <br>Note that in this case, <code>current</code> refers to the <code>period</code> in consideration (<code>min_date</code> till <code>max_date</code>), and <code>prev</code> refers to the previous period (<code>(min_date - (max_date - min_date))</code> till <code>min_date</code>)
    /// See <a href="https://corefork.telegram.org/type/StatsAbsValueAndPrev" />
    ///</summary>
    MyTelegram.Schema.IStatsAbsValueAndPrev ReactionsPerStory { get; set; }

    ///<summary>
    /// Percentage of subscribers with enabled notifications
    /// See <a href="https://corefork.telegram.org/type/StatsPercentValue" />
    ///</summary>
    MyTelegram.Schema.IStatsPercentValue EnabledNotifications { get; set; }

    ///<summary>
    /// Channel growth graph (absolute subscriber count)
    /// See <a href="https://corefork.telegram.org/type/StatsGraph" />
    ///</summary>
    MyTelegram.Schema.IStatsGraph GrowthGraph { get; set; }

    ///<summary>
    /// Followers growth graph (relative subscriber count)
    /// See <a href="https://corefork.telegram.org/type/StatsGraph" />
    ///</summary>
    MyTelegram.Schema.IStatsGraph FollowersGraph { get; set; }

    ///<summary>
    /// Muted users graph (relative)
    /// See <a href="https://corefork.telegram.org/type/StatsGraph" />
    ///</summary>
    MyTelegram.Schema.IStatsGraph MuteGraph { get; set; }

    ///<summary>
    /// Views per hour graph (absolute)
    /// See <a href="https://corefork.telegram.org/type/StatsGraph" />
    ///</summary>
    MyTelegram.Schema.IStatsGraph TopHoursGraph { get; set; }

    ///<summary>
    /// Interactions graph (absolute)
    /// See <a href="https://corefork.telegram.org/type/StatsGraph" />
    ///</summary>
    MyTelegram.Schema.IStatsGraph InteractionsGraph { get; set; }

    ///<summary>
    /// IV interactions graph (absolute)
    /// See <a href="https://corefork.telegram.org/type/StatsGraph" />
    ///</summary>
    MyTelegram.Schema.IStatsGraph IvInteractionsGraph { get; set; }

    ///<summary>
    /// Views by source graph (absolute)
    /// See <a href="https://corefork.telegram.org/type/StatsGraph" />
    ///</summary>
    MyTelegram.Schema.IStatsGraph ViewsBySourceGraph { get; set; }

    ///<summary>
    /// New followers by source graph (absolute)
    /// See <a href="https://corefork.telegram.org/type/StatsGraph" />
    ///</summary>
    MyTelegram.Schema.IStatsGraph NewFollowersBySourceGraph { get; set; }

    ///<summary>
    /// Subscriber language graph (pie chart)
    /// See <a href="https://corefork.telegram.org/type/StatsGraph" />
    ///</summary>
    MyTelegram.Schema.IStatsGraph LanguagesGraph { get; set; }

    ///<summary>
    /// A graph containing the number of reactions on posts categorized by emotion
    /// See <a href="https://corefork.telegram.org/type/StatsGraph" />
    ///</summary>
    MyTelegram.Schema.IStatsGraph ReactionsByEmotionGraph { get; set; }

    ///<summary>
    /// A graph containing the number of story views and shares
    /// See <a href="https://corefork.telegram.org/type/StatsGraph" />
    ///</summary>
    MyTelegram.Schema.IStatsGraph StoryInteractionsGraph { get; set; }

    ///<summary>
    /// A graph containing the number of reactions on stories categorized by emotion
    /// See <a href="https://corefork.telegram.org/type/StatsGraph" />
    ///</summary>
    MyTelegram.Schema.IStatsGraph StoryReactionsByEmotionGraph { get; set; }

    ///<summary>
    /// Detailed statistics about number of views and shares of recently sent messages and stories
    /// See <a href="https://corefork.telegram.org/type/PostInteractionCounters" />
    ///</summary>
    TVector<MyTelegram.Schema.IPostInteractionCounters> RecentPostsInteractions { get; set; }
}
