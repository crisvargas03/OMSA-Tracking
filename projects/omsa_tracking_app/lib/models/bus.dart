import 'package:omsa_tracking_app/models/driver.dart';

class Bus {
  int id;
  String name;
  double latitude;
  double longitude;
  String plate;
  String estimatedArrivalHour;
  int passengerLimit;
  int routeId;
  Driver driver;

  Bus({
    required this.id,
    required this.name,
    required this.latitude,
    required this.longitude,
    required this.plate,
    required this.estimatedArrivalHour,
    required this.passengerLimit,
    required this.routeId,
    required this.driver,
  });

  factory Bus.fromJson(Map<String, dynamic> json) {
    return Bus(
      id: json['id'],
      name: json['name'],
      latitude: double.parse(json['latitude']),
      longitude: double.parse(json['longitude']),
      plate: json['plate'],
      estimatedArrivalHour: json['estimatedArrivalHour'],
      passengerLimit: json['passengerLimit'],
      routeId: json['routeId'],
      driver: Driver.fromJson(json['driver']),
    );
  }
}
