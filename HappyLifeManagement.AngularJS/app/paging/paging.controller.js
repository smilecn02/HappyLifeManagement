'use strict';

var app = angular.module('myApp');

app.controller('PaginationDemoCtrl', PaginationDemoCtrl);

function PaginationDemoCtrl($scope, NoteService) {
    $scope.total = 0;

    NoteService.GetNotes().success(function (response) {
        $scope.notes = response.items;

        $scope.total = response.totalItemCount;
    });

    $scope.GetNotePagings = function (page) {
        NoteService.GetNotePagings(page).success(function (response) {
            $scope.notes = response.items;
        });
    };

};
