let express = require('express')
let app = express()
let mongoose = require('mongoose')
let connection = 'mongodb://localhost:27017/express'
let Cat = require('./models/Cat')
let Owner = require('./models/Owner')
let bodyParser = require('body-parser')
let stylus = require('stylus')
let path = require('path')
let multer = require('multer')
let upload = multer({ dest: 'uploads/' })

mongoose.Promise = global.Promise
mongoose.connect(connection)
app.use(express.static('public'))
app.use(bodyParser.urlencoded({ extended: false }))
app.use(stylus.middleware({
  src: path.join(__dirname, 'public'),
  dest: path.join(__dirname, 'public')
}))
app.set('view engine', 'pug')
app.set('views', 'public')
app.post('/create', (req, res) => {
  let ownerName = req.body.ownerName
  let catName = req.body.catName
  let age = req.body.age

  if (ownerName !== '' && catName !== '' && age !== '') {
    new Cat({
      name: catName,
      age: age
    })
      .save()
      .then(cat => {
        Owner
          .findOne({ name: ownerName })
          .then(owner => {
            if (owner === null) {
              new Owner({
                name: ownerName,
                cats: [cat]
              })
                .save()
                .then(newOwner => {
                  Cat
                    .findByIdAndUpdate(cat._id, { $set: { owner: newOwner } })
                    .exec()
                })
            } else {
              Owner
                .findByIdAndUpdate(owner._id, { $push: { cats: cat } })
                .exec()
              Cat
                .findByIdAndUpdate(cat._id, { $set: { owner: owner } })
                .exec()
            }
          })
      })
  }

  res.redirect('/')
})
app.get('/all', (req, res) => {
  Owner
    .find()
    .populate('cats')
    .then(owners => {
      res.render('all', { owners })
    })
})
app.get('/updateOwner/:id', (req, res) => {
  let id = req.params.id

  res.render('updateOwner', { id })
})
app.post('/updateOwner', (req, res) => {
  let name = req.body.name

  if (name !== undefined) {
    Owner
      .findByIdAndUpdate(req.body.id, { $set: { name: req.body.name } })
      .exec()
      .then((owner) => {
        res.redirect('/all')
      })
  } else {
    res.redirect('/all')
  }
})
app.get('/updateCat/:id', (req, res) => {
  let id = req.params.id

  res.render('updateCat', { id })
})
app.post('/updateCat', (req, res) => {
  let name = req.body.name
  let age = req.body.age
  let id = req.body.id

  if (name !== '' && age !== '') {
    Cat
      .findByIdAndUpdate(id, { $set: { name: name, age: age } })
      .exec()
      .then((cat) => {
        res.redirect('/all')
      })
  } else if (name !== '' && age === '') {
    Cat
      .findByIdAndUpdate(id, { $set: { name: name } })
      .exec()
      .then((cat) => {
        res.redirect('/all')
      })
  } else if (name === '' && age !== '') {
    Cat
      .findByIdAndUpdate(id, { $set: { age: age } })
      .exec()
      .then((cat) => {
        res.redirect('/all')
      })
  } else {
    res.redirect('/all')
  }
})
app.get('/deleteOwner/:id', (req, res) => {
  Owner
    .findOne({ _id: req.params.id })
    .then((owner) => {
      owner
        .remove()
        .then(() => {
          res.redirect('/all')
        })
    })
})
app.get('/deleteCat/:id', (req, res) => {
  Cat
    .findByIdAndRemove(req.params.id)
    .then(() => {
      res.redirect('/all')
    })
})
app.post('/fileUpload', upload.single('file'), (req, res) => {
  res.redirect('/')
})
app.listen(1000)
