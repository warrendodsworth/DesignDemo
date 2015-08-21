/*
 * Index Controller - Jobs Display
 */

( function () {
    'use strict';

    angular
        .module( 'JobAdder' )
        .controller( 'IndexController', IndexController );

    IndexController.$inject = ['$location', '$anchorScroll', '$http', '$scope', '$modal'];

    function IndexController( $location, $anchorScroll, $http, $scope, $modal ) {

        //Get Jobs
        $scope.filters = { page: 1, show: 10 };
        var init = false;

        $scope.pageChanged = function () {
            $http.get( '/api/jobs?page=' + $scope.filters.page + '&show=' + $scope.filters.show ).then( function ( res ) {
                $scope.jobs = res.data.items;
                $scope.total = res.data.total;

                if ( init ) {
                    $scope.gotoTop();
                }
                init = true;
            } )
        }
        $scope.pageChanged();


        //Get Single - Job details
        $scope.showJobDetails = function ( job ) {
            var modalInstance = $modal.open( {
                templateUrl: '/js/shared/templates/jobDetails.html',
                controller: 'ModalInstanceCtrl',
                size: 'lg',  
                resolve: {
                    job: function () {
                        return job; 
                    }
                }
            } );
        }

        //Scroll to top
        $scope.gotoTop = function () {
            // set the location.hash to the id of the element you wish to scroll to.
            $location.hash( 'top' );

            // call $anchorScroll()
            $anchorScroll();
        };
    }

    //Modal controller
    angular
        .module( 'JobAdder' )
        .controller( 'ModalInstanceCtrl', function ( $scope, $modalInstance, job ) {

            $scope.job = job;

            $scope.close = function () {
                $modalInstance.dismiss( 'cancel' );
            };
        } );
} )();