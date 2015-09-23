app.controller('VideoSystemController', function ($scope) {
	var videos = [
		{
			title: 'Course introduction',
			pictureUrl: 'http://www.w3schools.com/angular/pic_angular.jpg',
			length: '3:32',
			category: 'IT',
			subscribers: 3,
			date: new Date(2014, 12, 15),
			haveSubtitles: false,
			comments: [
				{
					username: 'Pesho Peshev',
					content: 'Congratulations Nakov',
					date: new Date(2014, 12, 15, 12, 30, 0),
					likes: 3,
					websiteUrl: 'http://pesho.com/'
				},
			]
		},
		{
			title: 'Intro to AngularJS',
			pictureUrl: 'http://www.w3schools.com/angular/pic_angular.jpg',
			length: '4:25',
			category: 'IT',
			subscribers: 5,
			date: new Date(2014, 12, 17),
			haveSubtitles: true,
			comments: [
				{
					username: 'Pesho',
					content: 'Congratulations Angel',
					date: new Date(2014, 12, 17, 12, 30, 0),
					likes: 5,
					websiteUrl: 'http://pesho.com/'
				},
			]
		},
		{
			title: 'Nature',
			pictureUrl: 'http://stylonica.com/wp-content/uploads/2014/02/nature.jpg',
			length: '2:11',
			category: 'Nature',
			subscribers: 55,
			date: new Date(2013, 8, 15),
			haveSubtitles: false,
			comments: [
				{
					username: 'Gosho',
					content: 'Beautiful',
					date: new Date(2013, 9, 16, 11, 34, 4),
					likes: 9001,
					websiteUrl: 'http://nature.com/'
				},
			]
		}
	];

	$scope.addVideo = function (newVideo) {
		var video = JSON.parse(JSON.stringify(newVideo));
		video.subscribers = 0;
		video.date = new Date();
		videos.push(video);
	};

	$scope.sortVideos = function (option) {
		$scope.sortingOption = option;
	};

	$scope.filterVideosByCategory = function (option) {
		$scope.filterByCategoryOption = option;
	};

	$scope.filterVideosByHavingSubs = function (option) {
		$scope.filterByHavingSubs = option;
	};

	$scope.videos = videos;
});