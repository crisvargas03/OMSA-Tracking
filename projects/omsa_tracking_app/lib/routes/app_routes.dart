import 'package:flutter/material.dart';
import '../presentation/turn_on_location_screen/turn_on_location_screen.dart';
import '../presentation/maps_and_bus_time_screen/maps_and_bus_time_screen.dart';
import '../presentation/favourite_stops_screen/favourite_stops_screen.dart';
import '../presentation/stop_buses_screen/stop_buses_screen.dart';
import '../presentation/app_navigation_screen/app_navigation_screen.dart';

class AppRoutes {
  static const String turnOnLocationScreen = '/turn_on_location_screen';

  static const String mapsAndBusTimeScreen = '/maps_and_bus_time_screen';

  static const String favouriteStopsScreen = '/favourite_stops_screen';

  static const String stopBusesScreen = '/stop_buses_screen';

  static const String appNavigationScreen = '/app_navigation_screen';

  static Map<String, WidgetBuilder> routes = {
    turnOnLocationScreen: (context) => TurnOnLocationScreen(),
    mapsAndBusTimeScreen: (context) => MapsAndBusTimeScreen(),
    favouriteStopsScreen: (context) => FavouriteStopsScreen(),
    stopBusesScreen: (context) => StopBusesScreen(),
    appNavigationScreen: (context) => AppNavigationScreen()
  };
}
