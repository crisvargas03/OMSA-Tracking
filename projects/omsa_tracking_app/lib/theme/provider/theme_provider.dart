import 'package:flutter/material.dart';
import 'package:omsa_tracking_app/core/utils/pref_utils.dart';
import 'package:provider/provider.dart';

class ThemeProvider extends ChangeNotifier {
  themeChange(String themeType) async {
    PrefUtils().setThemeData(themeType);
    notifyListeners();
  }
}
