let Tweet = require('../data/Tweet')

module.exports = {
  index: (req, res) => {
    Tweet
      .aggregate([
        { $limit: 100 },
        { $sort: { creationDate: -1 } }
      ])
      .then((tweets) => {
        for (let i = 0; i < tweets.length; i++) {
          Tweet
            .findByIdAndUpdate(tweets[i]._id, { $inc: { viewsCount: 1 } })
            .exec()
        }

        res.render('home/index', { tweets })
      })
  }
}
