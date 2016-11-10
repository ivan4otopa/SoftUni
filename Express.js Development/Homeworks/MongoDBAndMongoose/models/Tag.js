let mongoose = require('mongoose')
let Image = require('./Image')
let tagSchema = new mongoose.Schema({
  name: String,
  creationDate: { type: Date, default: Date.now },
  images: [{ type: mongoose.Schema.Types.ObjectId, ref: 'Image' }]
})

mongoose.model('Tag', tagSchema)

module.exports = mongoose.model('Tag')
