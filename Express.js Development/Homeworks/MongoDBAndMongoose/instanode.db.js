let Image = require('./models/Image')
let Tag = require('./models/Tag')
let saveImage = (data) => {
  new Image({
    url: data.url,
    description: data.description
  })
    .save()
    .then(image => {
      for (let i = 0; i < data.tags.length; i++) {
        Tag
          .findOne({ name: data.tags[i] })
          .then(tag => {
            if (tag === null) {
              new Tag({
                name: data.tags[i],
                images: [image]
              })
                .save()
                .then(newTag => {
                  Image
                    .findByIdAndUpdate(image._id, { $push: { tags: newTag } })
                    .exec()
                })
            } else {
              Image
                .findByIdAndUpdate(image._id, { $push: { tags: tag } })
                .exec()
              Tag
                .findByIdAndUpdate(tag._id, { $push: { images: image } })
                .exec()
            }
          })
      }
    })
}

let findByTag = (tagName) => {
  Tag
    .findOne({ name: tagName })
    .populate({ path: 'images', options: { sort: { 'creationDate': -1 } } })
    .then((tag) => console.log(tag.images))
}

let filter = (data) => {
  let results = data.results || 10

  if (data.after !== undefined && data.before !== undefined) {
    Image
      .find({ creationDate: { $gt: data.after, $lt: data.before } }).limit(results)
      .then(console.log)
  } else if (data.after === undefined && data.before !== undefined) {
    Image
      .find({ creationDate: { $lt: data.before } }).limit(results)
      .then(console.log)
  } else if (data.after !== undefined && data.before === undefined) {
    Image
      .find({ creationDate: { $gt: data.after } }).limit(results)
      .then(console.log)
  } else {
    Image
      .find().limit(results)
      .then(console.log)
  }
}

module.exports = {
  saveImage: saveImage,
  findByTag: findByTag,
  filter: filter
}
