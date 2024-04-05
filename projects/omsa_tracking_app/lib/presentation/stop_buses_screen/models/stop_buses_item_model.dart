import '../../../core/app_export.dart';

/// This class is used in the [stop_buses_item_widget] screen.
class StopBusesItemModel {
  StopBusesItemModel({
    this.weight,
    this.capacity,
    this.time,
    this.id,
  }) {
    weight = weight ?? "Bus B347G";
    capacity = capacity ?? "68 / 140";
    time = time ?? "6 min.";
    id = id ?? "";
  }

  String? weight;

  String? capacity;

  String? time;

  String? id;
}
