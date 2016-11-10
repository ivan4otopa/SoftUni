let mongoose = require('mongoose')
let Tag = require('./Tag')
let imageSchema = new mongoose.Schema({
  url: String,
  creationDate: { type: Date, default: Date.now },
  description: String,
  tags: [{ type: mongoose.Schema.Types.ObjectId, ref: 'Tag' }]
})

mongoose.model('Image', imageSchema)

module.exports = mongoose.model('Image')
