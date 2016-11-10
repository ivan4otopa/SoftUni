let mongoose = require('mongoose')
let connection = 'mongodb://localhost:27017/instanode'
let instanodeDb = require('./instanode.db')

mongoose.Promise = global.Promise
mongoose
  .connect(connection)
  .then(() => {
    console.log('MongoDB up and running!')
    // Problem 3
    // instanodeDb.saveImage({
    //   url: 'https://i.ytimg.com/vi/tntOCGkgt98/maxresdefault.jpg',
    //   description: 'such cat much wow',
    //   tags: ['cat', 'kitty', 'cute', 'catstagram']
    // })
    // instanodeDb.saveImage({
    //   url: 'https://d1wn0q81ehzw6k.cloudfront.net/additional/thul/media/4e34feee0acdc38a?w=400&h=400',
    //   description: 'such cat much wow',
    //   tags: ['cat', 'kitty', 'cute', 'catstagram']
    // })

    // Problem 4
    // instanodeDb.findByTag('cat')

    // Problem 5
    // let minDate = new Date(2016, 9, 24, 20, 42, 45)
    // let maxDate = new Date(2016, 9, 24, 20, 42, 47)

    // instanodeDb.filter({
    //   after: minDate,
    //   before: maxDate,
    //   results: 24
    // })
  })
