import '../../../core/app_export.dart';
import '../models/stop_buses_item_model.dart';
import 'package:flutter/material.dart';

// ignore: must_be_immutable
class StopBusesItemWidget extends StatelessWidget {
  StopBusesItemWidget(
    this.stopBusesItemModelObj, {
    Key? key,
  }) : super(
          key: key,
        );

  StopBusesItemModel stopBusesItemModelObj;

  @override
  Widget build(BuildContext context) {
    return Container(
      padding: EdgeInsets.symmetric(
        horizontal: 11.h,
        vertical: 13.v,
      ),
      decoration: AppDecoration.outlineBlack.copyWith(
        borderRadius: BorderRadiusStyle.roundedBorder8,
      ),
      child: Row(
        mainAxisAlignment: MainAxisAlignment.end,
        children: [
          CustomImageView(
            imagePath: ImageConstant.imgCar,
            width: 14.h,
            margin: EdgeInsets.only(left: 6.h),
          ),
          Padding(
            padding: EdgeInsets.only(
              left: 24.h,
              top: 2.v,
            ),
            child: Text(
              stopBusesItemModelObj.weight!,
              style: CustomTextStyles.bodySmallLight,
            ),
          ),
          Spacer(),
          CustomImageView(
            imagePath: ImageConstant.imgUpload,
            height: 14.v,
            margin: EdgeInsets.only(bottom: 2.v),
          ),
          Padding(
            padding: EdgeInsets.only(
              left: 6.h,
              top: 2.v,
            ),
            child: Text(
              stopBusesItemModelObj.capacity!,
              style: theme.textTheme.bodySmall,
            ),
          ),
          Padding(
            padding: EdgeInsets.only(
              left: 23.h,
              top: 2.v,
            ),
            child: Text(
              stopBusesItemModelObj.time!,
              style: theme.textTheme.labelLarge,
            ),
          ),
        ],
      ),
    );
  }
}
