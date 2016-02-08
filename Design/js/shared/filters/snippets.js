/*
 * Text shortner
 */

( function () {
    'use strict';

    angular
        .module( 'filters' )
        .filter( 'snippets', ['$sce', '$filter', function ( $sce, $filter ) {
            return function ( val, numberOfSnippets ) {
                //  var snippets = val.match( /(?:<br>)([\w\d\s\.])+(?=<br>)/ );

                val = val.replace( '<br> <br>', '<br>' );
                val = val.replace( '<br>  <br>', '<br>' );

                var snippets = val.match( /(?:<\/strong><br>)(.*?)(?=<br>)/g );
                var result = '';

                if ( snippets ) {
                    numberOfSnippets = numberOfSnippets > snippets.length ? snippets.length : numberOfSnippets;
                    for ( var i = 0; i < numberOfSnippets; i++ ) {
                        snippets[i] = $filter( 'limitTo' )( snippets[i], 120 );

                        if ( snippets[i].length > 15 ) {
                            result = result + snippets[i] + '... ';
                        }
                    }
                }

                return $sce.trustAsHtml( result );
            }
        }] );

} )();