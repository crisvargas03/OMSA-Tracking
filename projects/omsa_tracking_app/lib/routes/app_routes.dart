import 'package:flutter/material.dart';
import '../presentation/turn_on_location_screen/turn_on_location_screen.dart';
import '../presentation/maps_and_bus_time_screen/maps_and_bus_time_screen.dart';
import '../presentation/favourite_stops_screen/favourite_stops_screen.dart';
import '../presentation/stop_details_screen/stop_details_screen.dart';
import '../presentation/app_navigation_screen/app_navigation_screen.dart';

class AppRoutes {
  static const String turnOnLocationScreen = '/turn_on_location_screen';

  static const String mapsAndBusTimeScreen = '/maps_and_bus_time_screen';

  static const String favouriteStopsScreen = '/favourite_stops_screen';

  static const String stopDetailsScreen = '/stop_details_screen';

  static const String appNavigationScreen = '/app_navigation_screen';

  static Map<String, WidgetBuilder> routes = {
    turnOnLocationScreen: (context) => TurnOnLocationScreen(),
    mapsAndBusTimeScreen: (context) => MapsAndBusTimeScreen(),
    favouriteStopsScreen: (context) => FavouriteStopsScreen(),
    stopDetailsScreen: (context) => StopDetailsScreen(),
    appNavigationScreen: (context) => AppNavigationScreen()
  };
}
