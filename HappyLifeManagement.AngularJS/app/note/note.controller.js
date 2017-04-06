'use strict';
 
var app = angular.module('myApp');

app.controller('NoteController', NoteController);

NoteController.$inject = ['$scope', '$http', 'NoteService'];

function NoteController($scope, $http, NoteService) {

    NoteService.GetNotes().success(function (response) {
        $scope.notes = response;
    });
}