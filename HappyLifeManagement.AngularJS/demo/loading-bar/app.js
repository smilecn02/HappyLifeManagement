﻿
angular.module('LoadingBarExample', ['chieffancypants.loadingBar', 'ngAnimate'])
  .config(function (cfpLoadingBarProvider) {
      // true is the default, but I left this here as an example:
      cfpLoadingBarProvider.includeSpinner = true;
  })

  .controller('ExampleCtrl', function ($scope, $http, $timeout, cfpLoadingBar) {
      $scope.posts = [];
      $scope.section = null;
      $scope.subreddit = null;
      $scope.subreddits = ['cats', 'pics', 'funny', 'gaming', 'AdviceAnimals', 'aww'];

      var getRandomSubreddit = function () {
          var sub = $scope.subreddits[Math.floor(Math.random() * $scope.subreddits.length)];

          // ensure we get a new subreddit each time.
          if (sub == $scope.subreddit) {
              return getRandomSubreddit();
          }

          return sub;
      };

      $scope.fetch = function () {
          $scope.subreddit = getRandomSubreddit();
          // see how there's no need to keep track of these XHR requests?
          // the interceptor is doing all the work in the background
          // your controllers and services don't need to know anything about it!
          $http.jsonp('https://www.reddit.com/r/' + $scope.subreddit + '.json?limit=100&jsonp=JSON_CALLBACK').success(function (data) {
              // we're requesting 100 entries just to exaggerate the loading bar's progress
              // since this is just for an example, don't display all 100, just the first 5
              var posts = data.data.children.slice(0, 5);
              $scope.posts = posts;
          });
      };

      $scope.start = function () {
          cfpLoadingBar.start();
      };

      $scope.complete = function () {
          cfpLoadingBar.complete();
      };


      // fake the initial load so first time users can see the bar right away:
      $scope.start();
      $scope.fakeIntro = true;
      $timeout(function () {
          $scope.complete();
          $scope.fakeIntro = false;
      }, 1250);

  });