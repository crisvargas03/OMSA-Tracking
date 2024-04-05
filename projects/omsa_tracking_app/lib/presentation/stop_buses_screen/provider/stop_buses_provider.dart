import 'package:flutter/material.dart';
import '../../../core/app_export.dart';
import '../models/stop_buses_model.dart';
import '../models/stop_buses_item_model.dart';

/// A provider class for the StopBusesScreen.
///
/// This provider manages the state of the StopBusesScreen, including the
/// current stopBusesModelObj

// ignore_for_file: must_be_immutable
class StopBusesProvider extends ChangeNotifier {
  StopBusesModel stopBusesModelObj = StopBusesModel();

  @override
  void dispose() {
    super.dispose();
  }
}
