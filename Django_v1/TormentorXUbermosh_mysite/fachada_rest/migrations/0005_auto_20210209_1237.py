# Generated by Django 3.1.5 on 2021-02-09 11:37

from django.db import migrations, models


class Migration(migrations.Migration):

    dependencies = [
        ('fachada_rest', '0004_auto_20210209_1234'),
    ]

    operations = [
        migrations.AlterField(
            model_name='usuarios',
            name='contrasena',
            field=models.CharField(default='hola', max_length=100),
            preserve_default=False,
        ),
    ]
